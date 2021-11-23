using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingGroundGlow : MonoBehaviour
    {
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                print("OI");
            }
        }
    }
}
