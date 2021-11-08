using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class ScorePoint : MonoBehaviour
    {
        public GameObject winScreen;

        public AudioSource winSound;
        private bool winSoundIsPlay = false;

        public AudioSource deliveredSound;

        public static bool delivered = false;

        void Start()
        {
            ScoringSystem.theScore = 0;
        }

        void Update()
        {
            if(ScoringSystem.theScore == 10 && winSoundIsPlay == false)
            {
                winScreen.SetActive(true);
                Time.timeScale = 0;
                PlaySound();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                Destroy(other.gameObject);
                ScoringSystem.theScore += 1;
                deliveredSound.Play();
                delivered = true;
                Player.carryObject = false;
            }
        }

        void PlaySound()
        {
            winSound.Play();
            winSoundIsPlay = true;
        }
    }
}

