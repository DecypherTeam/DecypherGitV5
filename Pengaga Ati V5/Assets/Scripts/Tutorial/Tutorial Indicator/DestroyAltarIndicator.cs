using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyAltarIndicator : MonoBehaviour
    {
        public static bool deactivateAltar = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                deactivateAltar = true;
            }
        }
    }
}
