using UnityEngine;
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

        public bool playerShoot = false;

        Animator animator;

        public static bool carryObject = false;

        public AudioSource shootSound;

        //public GameObject crosshair;

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

            // Assigning the shooting mechanics to the shooting button
            if ( TCKInput.GetAction( "fireBtn", EActionEvent.Press ) && carryObject == false)
            {
                PlayerFiring();
                animator.SetBool("isShooting", true);
                //secondCamera.gameObject.SetActive(true);
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
            myTransform.Rotate( 0f, horizontal * 9f, 0f );
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
            //Transform camTransform = cameraTransform;
            rBody.AddForce( camTransform.forward * range, ForceMode.Impulse );
            Destroy( primitive, 0.5f );
            shootSound.Play();
        }

        // PlayerClicked
        public void PlayerClicked()
        {
            //Debug.Log( "PlayerClicked" );
        }
    };
}