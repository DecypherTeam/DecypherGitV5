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

        public GameObject ScorePlus;

        private bool addOne = false;

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

            if(addOne == true)
            {
                ScoringSystem.theScore += 1;
                addOne = false;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                addOne = true;
                Destroy(other.gameObject);
                //ScoringSystem.theScore += 1;
                deliveredSound.Play();
                delivered = true;
                Player.carryObject = false;
                PlayScoreUI();
            }
        }

        void PlaySound()
        {
            winSound.Play();
            winSoundIsPlay = true;
        }

        void PlayScoreUI()
        {
            Vector3 v = transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Euler(v.x, 0, v.z);
            GameObject clone = (GameObject)Instantiate(ScorePlus, transform.position, transform.rotation);
            Destroy(clone, 2.0f);
        }
    }
}

