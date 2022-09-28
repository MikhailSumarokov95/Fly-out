using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace ThirdPersonController
    {
        [RequireComponent(typeof(Rigidbody))]
        public class Car : MonoBehaviour
        {
            public static bool isKeyBoard = false;
            private Joystick joystick;

            [Range(1f, 20f)]
            [SerializeField]
            private float speed = 10;
            private Camera cam;
            [SerializeField]
            private WheelCollider rightWheel, leftWheel;

            private void Awake()
            {
                joystick = FindObjectOfType<Joystick>();   
            }
            private void Start()
            {
                cam = FindObjectOfType<Camera>();
                GetComponent<Rigidbody>().centerOfMass = 
                    new Vector3(0, (-transform.localPosition.y * 2) * transform.localScale.y, 0);
                if (isKeyBoard) joystick.gameObject.SetActive(false);
            }
            public float Angle
            {
                get { 
                    return Vector3.Angle(transform.forward, Move) *
                        ((Quaternion.Inverse(transform.rotation) * Move).x < 0 ? -1 : 1); 
                }
            }
            public Vector3 Move
            {
                get { 
                    if (isKeyBoard) 
                        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    return new Vector3(joystick.Direction.x, 0, joystick.Direction.y);
                }
            }

            private bool go = false;
            private float moveMagnitude = 0;
            private void Update()
            {
                if ((moveMagnitude == 0 && Move.magnitude != 0) || (moveMagnitude != 0 && Move.magnitude == 0))
                    go = (moveMagnitude = Move.magnitude) != 0;

                if (go)
                {
                    leftWheel.motorTorque = speed * Move.magnitude;
                    rightWheel.motorTorque = speed * Move.magnitude;
                } 
                else
                {
                    leftWheel.motorTorque = 0;
                    rightWheel.motorTorque = 0;
                }

                float angle = Angle + cam.rotate.y;
                rightWheel.steerAngle = angle;
                leftWheel.steerAngle = angle;
            }
        }
    }
}
