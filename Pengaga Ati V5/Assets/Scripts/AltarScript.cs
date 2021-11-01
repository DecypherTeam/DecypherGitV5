using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class AltarScript : MonoBehaviour
    {
        public static bool sacrificed = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC")
            {
                Destroy(other.gameObject);
                Debug.Log("Chicken is sacrificed");
                sacrificed = true;
            }
        }
    }
}

