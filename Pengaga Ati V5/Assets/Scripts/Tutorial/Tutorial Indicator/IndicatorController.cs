using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class IndicatorController : MonoBehaviour
    {
        public GameObject indicator;
        public GameObject indicatorChic;
        public GameObject indicatorAltar;
        public GameObject indicatorCrop;
        public GameObject indicatorLonghouse;

        public GameObject[] enemyCheck;
        public GameObject[] ghostCheck;

        private bool activateAltar = false;
        private bool activateCrop = false;
        private bool activateLonghouse = false;

        // Start is called before the first frame update
        void Start()
        {
            indicator.SetActive(false);
            indicatorChic.SetActive(false);
            indicatorAltar.SetActive(false);
            indicatorCrop.SetActive(false);
            indicatorLonghouse.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            // Tutorial indicator for the crop field
            if (TutorialIndicator.activate == true)
            {
                indicator.SetActive(true);
            }
            if(DestroyIndicator.deactivate == true)
            {
                indicator.SetActive(false);
            }

            // Tutorial indicator for the chicken
            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            ghostCheck = GameObject.FindGameObjectsWithTag("Ghost");
            if (enemyCheck.Length == 0 && ghostCheck.Length == 0)
            {
                indicatorChic.SetActive(true);
            }
            if(DestroyChicIndicator.deactivateChic == true)
            {
                indicatorChic.SetActive(false);
                activateAltar = true;
            }

            // Tutorial indicator for the altar
            if (activateAltar == true)
            {
                indicatorAltar.SetActive(true);
            }
            if(DestroyAltarIndicator.deactivateAltar == true)
            {
                indicatorAltar.SetActive(false);
                activateCrop = true;
            }

            // Tutorial indicator for the crop
            if(activateCrop == true)
            {
                indicatorCrop.SetActive(true);
            }
            if(DestroyCropIndicator.deactivateCrop == true)
            {
                indicatorCrop.SetActive(true);
                activateLonghouse = true;
            }
        }
    }
}
