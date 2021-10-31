using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class GrownCheck1 : MonoBehaviour
    {
        public static bool plantIsGrown1 = false;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                print("Plant is fully grown");
                plantIsGrown1 = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                print("Plant is not fully grown");
                plantIsGrown1 = false;
            }
        }
    }
}

