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


        public GameObject[] enemyCheck;
        public GameObject[] ghostCheck;

        private bool activateAltar = false;

        // Start is called before the first frame update
        void Start()
        {
            indicator.SetActive(false);
            indicatorChic.SetActive(false);
            indicatorAltar.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (TutorialIndicator.activate == true)
            {
                indicator.SetActive(true);
            }

            if(DestroyIndicator.deactivate == true)
            {
                indicator.SetActive(false);
            }

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

            if(activateAltar == true)
            {
                indicatorAltar.SetActive(true);
            }

            if(DestroyAltarIndicator.deactivateAltar == true)
            {
                indicatorAltar.SetActive(false);
            }
        }
    }
}
