using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ToxicFamilyGames
{
    namespace ThirdPersonController
    {
        [RequireComponent(typeof(CharacterController))]
        public class Character : MonoBehaviour
        {
            public static bool isKeyBoard = false;
            private Joystick joystick;

            [Header("Скорость персонажа")]
            [SerializeField]
            [Range(1f, 3f)]
            private float walkingSpeed = 1.674f;

            [Range(3f, 6f)]
            [SerializeField]
            private float runSpeed = 4.177f;

            [SerializeField]
            private float rotateSpeed = 10f;

            private Camera cam;
            private Animator animator;
            private CharacterController characterController;
            // Start is called before the first frame update

            private void Awake()
            {
                joystick = FindObjectOfType<Joystick>();
            }
            void Start()
            {
                cam = FindObjectOfType<Camera>();
                animator = GetComponent<Animator>();
                characterController = GetComponent<CharacterController>();
                if (isKeyBoard) joystick.gameObject.SetActive(false);
            }

            // Update is called once per frame
            void Update()
            {
                Movement();
            }

            private float moveMagnitude = 0;
            public Vector2 Move
            {
                get
                {
                    if (isKeyBoard) return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
                    return joystick.Direction;
                }
            }

            public bool Run
            {
                get
                {
                    if (isKeyBoard) return Input.GetKey(KeyCode.LeftShift);
                    return joystick.Direction.magnitude >= 0.9;
                }
            }
            private void Movement()
            {
                animator.SetBool("isRunning", Run);

                if ((moveMagnitude == 0 && Move.magnitude != 0) || moveMagnitude != 0 && Move.magnitude == 0)
                    animator.SetBool("isWalking", (moveMagnitude = Move.magnitude) != 0);

                float angle = Vector2.Angle(Vector2.up, Move) * ((Move.x < 0) ? -1 : 1);

                if (animator.GetBool("isWalking"))
                {
                    characterController.SimpleMove(transform.forward * (animator.GetBool("isRunning") ? runSpeed : walkingSpeed));
                    transform.localRotation =
                        Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, cam.rotate.y + angle, 0), rotateSpeed * Time.deltaTime);
                }
            }
        }
    }
}
