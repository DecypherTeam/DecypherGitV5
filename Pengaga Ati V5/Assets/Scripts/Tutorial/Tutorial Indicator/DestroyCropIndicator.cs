using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyCropIndicator : MonoBehaviour
    {
        public static bool deactivateCrop = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                deactivateCrop = true;
            }
        }
    }
}
