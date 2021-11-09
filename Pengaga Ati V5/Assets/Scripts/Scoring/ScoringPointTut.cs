using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples { 
    public class ScoringPointTut : MonoBehaviour
    {
        public GameObject winScreen;

        public AudioSource winSound;
        private bool winSoundIsPlay = false;

        public AudioSource deliveredSound;

        public static bool delivered = false;

        public GameObject deliveredBtn;

        private bool addOne = false;

        void Start()
        {
            ScoringSystemTutorial.theScore = 0;
        }

        void Update()
        {
            if (ScoringSystemTutorial.theScore == 1 && winSoundIsPlay == false)
            {
                deliveredBtn.SetActive(false);
                winScreen.SetActive(true);
                Time.timeScale = 0;
                PlaySound();
            }

            if (addOne == true)
            {
                ScoringSystemTutorial.theScore += 1;
                addOne = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                addOne = true;
                Destroy(other.gameObject);
                deliveredSound.Play();
                delivered = true;
                Player.carryObject = false;
                print("addOne is true");
            }
    }

        void PlaySound()
        {
            winSound.Play();
            winSoundIsPlay = true;
        }
    }
}
