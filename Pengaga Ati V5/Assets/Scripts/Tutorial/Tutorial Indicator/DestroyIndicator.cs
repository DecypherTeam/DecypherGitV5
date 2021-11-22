using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyIndicator : MonoBehaviour
    {
        public static bool deactivate = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                deactivate = true;
            }
        }
    }
}
