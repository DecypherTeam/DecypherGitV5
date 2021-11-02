using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class PlaneTrigger : MonoBehaviour
    { 
        public AudioSource bagDrop;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Chillie SeedBag")
            {
                print("drop");
                bagDrop.Play();
            }
        }
    }
}

