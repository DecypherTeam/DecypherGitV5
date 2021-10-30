using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class GrowingHand : MonoBehaviour
    {
        plantScript planting;

        public Transform farm1;

        private bool handInPosition = false;

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnPlant = GameObject.Find("Spawnplant");
            planting = spawnPlant.GetComponent<plantScript>();
        }

        // Update is called once per frame
        void Update()
        {
            handInPosition = false;

            if(planting.seedPlanted == true)
            {
                transform.position = farm1.position;
                handInPosition = true;
            }

            if(handInPosition == true)
            {
                planting.spawnplant();
                handInPosition = false;
            }
        }
    }
}

