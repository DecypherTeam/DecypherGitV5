using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class FarmingGroundGlow : MonoBehaviour
    {
        [SerializeField] private GameObject mesh;

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player" && ObjectPickUp.carryingBag == true)
            {
                mesh.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.cyan);
            }

            if (other.gameObject.tag == "Plant" || other.gameObject.name == "Chillie Crop(Clone)")
            {
                mesh.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
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
