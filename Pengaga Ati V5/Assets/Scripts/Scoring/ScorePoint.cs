using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class ScorePoint : MonoBehaviour
    {
        public GameObject winScreen;

        void Update()
        {
            if(ScoringSystem.theScore == 10)
            {
                winScreen.SetActive(true);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                Destroy(other.gameObject);
                ScoringSystem.theScore += 1;
            }
        }
    }
}

