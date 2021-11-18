using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class ThirdPersonCameraController : MonoBehaviour
    {
        public float RotationSpeed = 1;
        public Transform Target;
        float moveX, moveY;

        // Start is called before the first frame update
        void Start()
        {

        }

        void Update()
        {
            Vector2 look = TCKInput.GetAxis("Touchpad");
            CamControl(look.x, look.y);
        }

        void CamControl(float horizontal, float vertical)
        {
            moveX = horizontal * RotationSpeed;
            moveY = vertical * RotationSpeed;

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(moveY, moveX, 0);

        }
    }
}
