using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class IndicatorController : MonoBehaviour
    {
        public GameObject indicator;
        public GameObject indicatorChic;

        public GameObject[] enemyCheck;

        // Start is called before the first frame update
        void Start()
        {
            indicator.SetActive(false);
            indicatorChic.SetActive(false);
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
            if (enemyCheck.Length == 0)
            {

            }
        }
    }
}
