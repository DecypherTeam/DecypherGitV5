using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingGroundGlow : MonoBehaviour
    {
        public GameObject mesh;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && other.gameObject.tag != "Plant" && ObjectPickUp.carryingBag == true)
            {
                print("OI");
                mesh.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.cyan);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
