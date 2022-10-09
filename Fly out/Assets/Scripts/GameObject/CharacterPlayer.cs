using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ToxicFamilyGames.AdsBrowser;

public class CharacterPlayer : MonoBehaviour
{
    [SerializeField] private Rigidbody pointAddForce;
    [SerializeField] private float factorForceFlyFormCar = 500f;
    [SerializeField] private float factorForceTaxiing = 10000;
    private LeaderBoard _leaderBoard;
    private int _scoreTarget = -1;
    private float _timerDelayAfterCounting;
    private bool _isCrashedWithCollision;
    private Rigidbody _characterPlayerRB;
    private bool _isPushed;
    private bool _isBannedPushing = true;
    private bool _isMobile;
    private VariableJoystick _variableJoystick;
    readonly float _delayAfterCounting = 1f;
    public float PowerStartForce { get; set; }
    public float AngleStartForce { get; set; }
    public float AngleTurnCarY { get; set; }

    private void Start()
    {
        _leaderBoard = FindObjectOfType<LeaderBoard>();
        FlyOutCar();
        _characterPlayerRB = GetComponent<Rigidbody>();
        _isMobile = YandexSDK.instance.isMobile();
        if (_isMobile) _variableJoystick = FindObjectOfType<VariableJoystick>();
    }

    private void Update()
    {
        if (_scoreTarget > -1) _timerDelayAfterCounting += Time.deltaTime;
        if (_timerDelayAfterCounting > _delayAfterCounting)
        {
            _leaderBoard.StartLeaderBoard(_scoreTarget, false);
            GetComponent<CharacterPlayer>().enabled = false;
        }
        if (!_isPushed) Push();
    }

    private void FlyOutCar()
    {
        var vectorForce = new Vector3(Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Sin(AngleTurnCarY * Mathf.Deg2Rad),
            Mathf.Sin(AngleStartForce * Mathf.PI / 2),
            Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Cos(AngleTurnCarY * Mathf.Deg2Rad)) * PowerStartForce * factorForceFlyFormCar;
        pointAddForce.AddForce(vectorForce, ForceMode.Impulse);
    }

    private void Push()
    {
        Vector2 direction;
        if (_isMobile) direction = _variableJoystick.Direction;
        else direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (_isBannedPushing)
        {
            _isBannedPushing = !(direction.magnitude == 0);
            return;
        }
        _characterPlayerRB.AddForce((Vector3)direction * factorForceTaxiing);
        _isPushed = direction.magnitude != 0;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (_isCrashedWithCollision) return;
        if (collision.gameObject.tag == "Target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            _isCrashedWithCollision = true;
        }
        if (collision.gameObject.tag == "Ground")
        {
            _leaderBoard.StartLeaderBoard(0, false);
            GetComponent<CharacterPlayer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            _isCrashedWithCollision = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            if (_scoreTarget < int.Parse(other.gameObject.name)) 
                _scoreTarget = int.Parse(other.gameObject.name);
        }
    }
}
