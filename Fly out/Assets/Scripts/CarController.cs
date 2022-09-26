using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{

    public WheelCollider[] WColForward;
    public WheelCollider[] WColBack;
    public float maxSteer = 30;
    public float maxAccel = 25;
    public float maxBrake = 50;
    public Transform COM;

    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = COM.localPosition;
    }

    void FixedUpdate()
    {
        float accel = 0;
        float steer = 0;
        accel = Input.GetAxis("Vertical");
        steer = Input.GetAxis("Horizontal");
        CarMove(accel, steer);
    }

    private void CarMove(float accel, float steer)
    {

        foreach (WheelCollider col in WColForward)
        {
            col.steerAngle = steer * maxSteer;
        }

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