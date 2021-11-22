using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class DestroyIndicator : MonoBehaviour
    {
        public GameObject indicator;

        void Update()
        {
            if (TutorialIndicator.nextIndicator == true)
            {
                indicator.SetActive(true);
                print("it work?");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                indicator.SetActive(false);
                print("set active faalse brother");
            }
        }
    }
}
