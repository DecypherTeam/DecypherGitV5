using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class TimerCountdown : MonoBehaviour
    {
        public GameObject textDisplay;
        public int secondsLeft = 11;
        public bool takingAway = false;

        public GameObject loseScreen;
      
        void Start()
        {
            textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }

        void Update()
        {
            if(takingAway == false && secondsLeft > 0)
            {
                StartCoroutine(TimerTake());
            }

            if(secondsLeft == 0 && ScoringSystem.theScore < 10)
            {
                loseScreen.SetActive(true);
            }
        }

        IEnumerator TimerTake()
        {
            takingAway = true;
            yield return new WaitForSeconds(1);
            secondsLeft -= 1;
            if (secondsLeft < 10)
            {
                textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
            }
            else
            {
                textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
            }
            if (secondsLeft >= 60)
            {
                textDisplay.GetComponent<Text>().text = "01:" + secondsLeft;
            }

            takingAway = false;
        }
    }
}

