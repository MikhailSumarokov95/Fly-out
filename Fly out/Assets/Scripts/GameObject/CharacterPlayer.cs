using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterPlayer : MonoBehaviour
{ 
    [SerializeField] private Rigidbody pointAddForce;
    [SerializeField] private float factorForce = 500f;
    private Score _score;
    public float PowerStartForce { get; set; }
    public float AngleStartForce { get; set; }
    public float AngleTurnCarY { get; set; }


    private void Start()
    { 
        _score = FindObjectOfType<Score>();
        var vectorForce = new Vector3(Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Sin(AngleTurnCarY * Mathf.Deg2Rad),
        Mathf.Sin(AngleStartForce * Mathf.PI / 2),
        Mathf.Cos(AngleStartForce * Mathf.PI / 2) * Mathf.Cos(AngleTurnCarY * Mathf.Deg2Rad)) * PowerStartForce * factorForce;
        pointAddForce.AddForce(vectorForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
            _score.CountScore(int.Parse(collision.gameObject.name));
        }
        if (collision.gameObject.tag == "Ground")
        {
            _score.CountScore(0);
            print("Ground");
        }

    }
}
