using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class GrownCheck : MonoBehaviour
    {
        public static bool plantIsGrown;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Plant")
            {
                print("Plant is fully grown");
                plantIsGrown = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                print("Plant is not fully grown");
                plantIsGrown = false;
            }
        }
    }
}

