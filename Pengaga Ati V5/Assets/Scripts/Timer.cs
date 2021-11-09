using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class Timer : MonoBehaviour
    {
        public float timeValue = 90;
        public Text timeText;

        public GameObject loseScreen;

        public AudioSource loseSound;
        private bool soundIsPlaying = false;

        void Update()
        {
            if (PauseMenu.startTime == true && timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
                loseScreen.SetActive(true);
                if(timeValue == 0 && soundIsPlaying == false)
                {
                    PlaySound();
                    Time.timeScale = 0;
                }
            }
            if (AltarScript.sacrificed == true)
            {
                timeValue += 40;
                AltarScript.sacrificed = false;
            }

            DisplayTime(timeValue);
        }

        void DisplayTime(float timeToDisplay)
        {
            if(timeToDisplay < 0)
            {
                timeToDisplay = 0;
            }

            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);

            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
        }

        void PlaySound()
        {
            loseSound.Play();
            soundIsPlaying = true;
        }
    } 
}

