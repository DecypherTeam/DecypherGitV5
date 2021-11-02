using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class PlantIndicator : MonoBehaviour
    {
        public static bool landIsAvailable = true;

        void Start()
        {
            
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                landIsAvailable = false;
                print("land is not available");
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                landIsAvailable = true;
                print("land is available");
            }
        }
    }
}

