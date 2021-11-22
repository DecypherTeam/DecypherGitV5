using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyIndicator : MonoBehaviour
    {
        //public GameObject indicatorPlant;

        void Start()
        {
            this.gameObject.SetActive(false);
            print("its not visible yet");
        }

        void Update()
        {
            if (TutorialIndicator.nextIndicator == true)
            {
                this.gameObject.SetActive(true);
                //print("it work?");
            }
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                indicator.SetActive(false);
                print("set active faalse brother");
            }
        }*/
    }
}
