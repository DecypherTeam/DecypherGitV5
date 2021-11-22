using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class TutorialIndicator : MonoBehaviour
    {
        private GameObject[] indicatorUI;
        public static bool activate = false;

        void Start()
        {

        }

        void Update()
        {
            indicatorUI = GameObject.FindGameObjectsWithTag("IndicatorUI");
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                indicatorUI[0].SetActive(false);
                activate = true;
                print("activate is true");
            }
        }
    }
}
