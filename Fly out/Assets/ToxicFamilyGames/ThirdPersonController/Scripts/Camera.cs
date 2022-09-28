using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace ThirdPersonController
    {
        public class Camera : MonoBehaviour
        {
            [SerializeField]
            private Transform followTarget;
            [SerializeField]
            private float followSpeed = 10;

            [Header("Положение камеры")]
            [SerializeField]
            private bool isRadiusAuto = true;
            [SerializeField]
            private bool isFixed = false;
            [Range(0f, 10f)]
            [SerializeField]
            private float radius;

            [SerializeField]
            private Vector3 offset;
            private void Start()
            {
                startRotation = transform.localRotation;
                startPosition = transform.localPosition;
            }

            private Vector3 startPosition;
            private Quaternion startRotation;
            private float rotateX = 0, rotateY = 0;
            public Vector2 rotate
            {
                get { return new Vector2(rotateX, rotateY); }
            }

            private void Update()
            {
                if (followTarget == null) return;
                if (isRadiusAuto)
                {
                    radius = (offset).magnitude;
                    isRadiusAuto = false;
                }
                transform.parent.position =
                    Vector3.Lerp(transform.parent.position, followTarget.position, followSpeed * Time.deltaTime);

                transform.localPosition = (startPosition = Vector3.Lerp(startPosition, offset.normalized * radius, followSpeed * Time.deltaTime));

                if (isFixed) return;

                transform.localRotation = startRotation;

                rotateY += Input.GetAxis("Mouse X");
                rotateX += -Input.GetAxis("Mouse Y");
                if (rotateY > 360 || rotateY < -360) rotateY += Mathf.Sign(rotateY) * 360;

                Quaternion rotate = Quaternion.Euler(rotateX, rotateY, 0);

                transform.localRotation *= rotate;
                transform.localPosition = rotate * transform.localPosition;
            }

            public void SetTargetFollow(GameObject target) => followTarget = target.transform;
        }
    }
}