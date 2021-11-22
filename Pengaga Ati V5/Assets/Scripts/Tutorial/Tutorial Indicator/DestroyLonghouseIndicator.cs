using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyLonghouseIndicator : MonoBehaviour
    {
        public static bool deactivateLonghouse = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                deactivateLonghouse = true;
            }
        }
    }
}
