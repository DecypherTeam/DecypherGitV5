using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyChicIndicator : MonoBehaviour
    {
        public static bool deactivateChic = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                deactivateChic = true;
            }
        }
    }
}
