using UnityEngine;
using System.Collections;
using ToxicFamilyGames.AdsBrowser;

public class CarPlayer : MonoBehaviour
{
    [SerializeField] private WheelCollider[] WColForward;
    [SerializeField] private WheelCollider[] WColBack;
    [SerializeField] private float maxSteer = 30;
    [SerializeField] private float maxAccel = 2500;
    [SerializeField] private float maxBrake = 50;
    [SerializeField] private Transform centerOfMass;
    private bool _isBanControl;
    private bool _isMobile;
    private VariableJoystick _variableJoystick;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass.localPosition;
        _isMobile = YandexSDK.instance.isMobile();
        if (_isMobile) _variableJoystick = FindObjectOfType<VariableJoystick>();
    }

    private void FixedUpdate()
    {
        if (_isBanControl) return;
        if (_isMobile)
        {
            Move(_variableJoystick.Horizontal);
            Turn(_variableJoystick.Vertical);
        }
        else
        {
            Move(Input.GetAxis("Horizontal"));
            Turn(Input.GetAxis("Vertical"));
        }
    }

    public void BanControl() => _isBanControl = true;

    private void Move(float steer)
    {
        foreach (WheelCollider col in WColForward)
        {
            col.steerAngle = steer * maxSteer;
        }
    }

    private void Turn(float accel)
    {
        if (accel != 0)
        {
            foreach (WheelCollider col in WColBack)
            {
                col.brakeTorque = 0;
                col.motorTorque = accel * maxAccel;
            }
 
        }
        else
        {
            foreach (WheelCollider col in WColBack)
            {
                col.brakeTorque = maxBrake;
            }
        }
    }
}
