using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class CameraControl : MonoBehaviour
    {
        Vector3 cameraDirection;
        float camDistance;
        Vector2 cameraDistanceMinMax = new Vector2(0.5f, 10f);
        public Transform cam;

        void Start()
        {
            cameraDirection = cam.transform.localPosition.normalized;
            camDistance = cameraDistanceMinMax.y;
        }

        void Update()
        {
            CheckCameraOcclusionAndCollision(cam);
        }

        public void CheckCameraOcclusionAndCollision(Transform cam)
        {
            Vector3 desiredCameraPosition = transform.TransformPoint(cameraDirection * cameraDistanceMinMax.y);
            RaycastHit hit;
            if(Physics.Linecast(transform.position, desiredCameraPosition, out hit))
            {
                camDistance = Mathf.Clamp(hit.distance, cameraDistanceMinMax.x, cameraDistanceMinMax.y);
            }
            else
            {
                camDistance = cameraDistanceMinMax.y;
            }

            cam.localPosition = cameraDirection * camDistance;
        }
    }
}
