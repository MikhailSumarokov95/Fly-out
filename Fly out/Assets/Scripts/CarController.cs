using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    [SerializeField] private WheelCollider[] WColForward;
    [SerializeField] private WheelCollider[] WColBack;
    [SerializeField] private float maxSteer = 30;
    [SerializeField] private float maxAccel = 2500;
    [SerializeField] private float maxBrake = 50;
    [SerializeField] private Transform COM;

    private void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = COM.localPosition;
    }

    private void Update()
    {
        Move(Input.GetAxis("Horizontal"));
        Turn(Input.GetAxis("Vertical"));
    }

    private void Move(float steer)
    {
        foreach (WheelCollider col in WColForward)
        {
            col.steerAngle = steer * maxSteer;
        }
    }

    private void Turn(float accel)
    {
        if (accel == 0)
        {
            foreach (WheelCollider col in WColBack)
            {
                col.brakeTorque = maxBrake;
            }
        }
        else
        {
            foreach (WheelCollider col in WColBack)
            {
                col.brakeTorque = 0;
                col.motorTorque = accel * maxAccel;
            }
        }
    }
}
