﻿using UnityEngine;
using TouchControlsKit;
namespace Examples
{
    public class Player : MonoBehaviour
    {
        bool binded;
        Transform myTransform, cameraTransform;
        CharacterController controller;
        float rotation;
        bool jump, prevGrounded;
        float weapReadyTime;
        bool weapReady = true;

        public Transform bulletDest;
        public float range;

        public Camera secondCamera;

        public GameObject sumpit;

        public Transform pickUpDest;

        // List of variable for all chickens [START]
        public Rigidbody pickChic;
        public bool pickedChic;
        public Rigidbody pickChicSec;
        public bool pickedChicSec;
        public Rigidbody pickChicThird;
        public bool pickedChicThird;
        public Rigidbody pickChicFourth;
        public bool pickedChicFourth;
        // [END]

        public bool playerShoot = false;

        public GameObject joystick;

        Animator animator;

        // Awake
        void Awake()
        {
            myTransform = transform;
            cameraTransform = Camera.main.transform;
            controller = GetComponent<CharacterController>();
        }

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        // Update
        void Update()
        {
            // Setting up the shooting mechanics
            if ( weapReady == false )
            {
                weapReadyTime += Time.deltaTime;
                if( weapReadyTime > 1f )
                {
                    weapReady = true;
                    weapReadyTime = 0f;
                }
            }

            // Assigning the pick up mechanics to the pick up button
            if( TCKInput.GetAction( "pickBtn", EActionEvent.Press))
            {
                // List of calling pick chicken up functions [START]
                if (pickedChic == false && pickChic != null)
                {
                    PickChicUp();
                    animator.SetBool("isPickup", true);
                    pickedChicSec = true;
                    pickedChicThird = true;
                    pickedChicFourth = true;
                }
                if (pickedChicSec == false && pickChicSec != null)
                {
                    PickChicUpSec();
                    animator.SetBool("isPickup", true);
                    pickedChic = true;
                    pickedChicThird = true;
                    pickedChicFourth = true;
                }
                if(pickedChicThird == false && pickChicThird != null)
                {
                    PickChicUpThird();
                    animator.SetBool("isPickup", true);
                    pickedChic = true;
                    pickedChicSec = true;
                    pickedChicFourth = true;

                }
                if(pickedChicFourth == false && pickChicFourth != null)
                {
                    PickChicUpFourth();
                    animator.SetBool("isPickup", true);
                    pickedChic = true;
                    pickedChicSec = true;
                    pickedChicThird = true;
                }
                //[END]
            }

            // Assigning the item to drop when the button is not pressed
            if (TCKInput.GetAction("pickBtn", EActionEvent.Up))
            {
                // List of calling pick chicken down functions
                if(pickChic != null)
                {
                    PickChicDown();
                    PickChicDownSec();
                    PickChicDownThird();
                    PickChicDownFourth();
                }
            }

            // Assigning the shooting mechanics to the shooting button
            if ( TCKInput.GetAction( "fireBtn", EActionEvent.Press ) )
            {
                PlayerFiring();
                animator.SetBool("isShooting", true);
                secondCamera.gameObject.SetActive(true);
                sumpit.gameObject.SetActive(true);
                playerShoot = true;
            }
            else
            {
                animator.SetBool("isShooting", false);
                sumpit.gameObject.SetActive(false);
                playerShoot = false;
            }

            // Navigating the camera angles according to the player's touch on the touchpad area of the screen
            Vector2 look = TCKInput.GetAxis( "Touchpad" );
            PlayerRotation( look.x, look.y );
        }

        // FixedUpdate
        void FixedUpdate()
        {
            // List of booleans for picking chickens
            pickedChic = true;
            pickedChicSec = true;
            pickedChicThird = true;
            pickedChicFourth = true;
            
            // Assign the movement of the character to a joystick
            Vector2 move = TCKInput.GetAxis( "Joystick" ); 
            PlayerMovement(move.x, move.y);
        }


        // Jumping
        private void Jumping()
        {
            if( controller.isGrounded )
                jump = true;
        }

                        
        // PlayerMovement
        private void PlayerMovement( float horizontal, float vertical )
        {
            secondCamera.gameObject.SetActive(false);

            bool grounded = controller.isGrounded;

            Vector3 moveDirection = myTransform.forward * vertical * 2f;
            moveDirection += myTransform.right * horizontal * 1f;

            if(playerShoot == true)
            {
                moveDirection = myTransform.forward * vertical * 0.5f;
                moveDirection += myTransform.right * horizontal * 0.5f;
            }

            moveDirection.y = -10f;

            if (moveDirection.z < 0f || moveDirection.z > 0f)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }

            if ( jump )
            {
                jump = false;
                moveDirection.y = 25f;
            }

            if( grounded )            
                moveDirection *= 5f;
            
            controller.Move( moveDirection * Time.fixedDeltaTime);
            moveDirection = Vector3.zero;

            if( !prevGrounded && grounded )
                moveDirection.y = 0f;
  
            prevGrounded = grounded;
        }

        // PlayerRotation
        public void PlayerRotation( float horizontal, float vertical )
        {
            myTransform.Rotate( 0f, horizontal * 12f, 0f );
            rotation += vertical * 12f;
            rotation = Mathf.Clamp( rotation, -60f, 60f );
            cameraTransform.localEulerAngles = new Vector3(9.61f, cameraTransform.localEulerAngles.y, 0f );
        }

        // PlayerFiring
        public void PlayerFiring()
        {
            if ( !weapReady )
                return;

            weapReady = false;

            // Setting up the bullets 
            GameObject primitive = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            primitive.transform.position = bulletDest.position;
            primitive.transform.localScale = Vector3.one * .2f;
            Rigidbody rBody = primitive.AddComponent<Rigidbody>();
            Transform camTransform = secondCamera.transform;
            rBody.AddForce( camTransform.forward * range, ForceMode.Impulse );
            Destroy( primitive, 0.5f );
        }



        // Lists of functions handling all chicken functions
        // Function for chicken number 1 [START]
        private void PickChicUp()
        {
            /*Debug.Log("Pick Chicken");*/
            pickChic.useGravity = false;
            pickChic.transform.position = pickUpDest.position;
            pickChic.transform.parent = GameObject.Find("PickUpDestination").transform;
            /*pickChic.constraints = RigidbodyConstraints.FreezeAll;*/
        }
        private void PickChicDown()
        {
            if (pickChic != null)
            {
                pickChic.transform.parent = null;
                pickChic.useGravity = true;
                animator.SetBool("isPickup", false);
            }
        }
        // Function for chicken number 1 [END]
        // Function for chicken number 2 [START]
        private void PickChicUpSec()
        {
            pickChicSec.useGravity = false;
            pickChicSec.transform.position = pickUpDest.position;
            pickChicSec.transform.parent = GameObject.Find("PickUpDestination").transform;
        }
        private void PickChicDownSec()
        {
            if (pickChicSec != null)
            {
                pickChicSec.transform.parent = null;
                pickChicSec.useGravity = true;
                animator.SetBool("isPickup", false);
            }
        }
        // Function for chicken number 2 [END]
        // Function for chicken number 3 [START]
        private void PickChicUpThird()
        {
            pickChicThird.useGravity = false;
            pickChicThird.transform.position = pickUpDest.position;
            pickChicThird.transform.parent = GameObject.Find("PickUpDestination").transform;
        }
        private void PickChicDownThird()
        {
            if(pickChicThird != null)
            {
                pickChicThird.transform.parent = null;
                pickChicThird.useGravity = true;
                animator.SetBool("isPickup", false);
            }
        }
        // Function for chicken number 3 [END]
        // Function for chicken number 4 [START]
        private void PickChicUpFourth()
        {
            pickChicFourth.useGravity = false;
            pickChicFourth.transform.position = pickUpDest.position;
            pickChicFourth.transform.parent = GameObject.Find("PickUpDestination").transform;
        }
        private void PickChicDownFourth()
        {
            if (pickChicFourth != null)
            {
                pickChicFourth.transform.parent = null;
                pickChicFourth.useGravity = true;
                animator.SetBool("isPickup", false);
            }
        }
        // Function for chicken number 4 [END]



        // PlayerClicked
        public void PlayerClicked()
        {
            //Debug.Log( "PlayerClicked" );
        }
    };
}