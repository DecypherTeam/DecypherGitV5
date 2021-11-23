using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingGroundGlow : MonoBehaviour
    {
        public GameObject mesh;

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && ObjectPickUp.carryingBag == true)
            {
                mesh.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.cyan);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
            }
        }
    }
}
