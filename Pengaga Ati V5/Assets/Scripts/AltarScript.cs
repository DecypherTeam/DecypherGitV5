using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class AltarScript : MonoBehaviour
    {
        public static bool sacrificed = false;
        public static bool sacrificedForReal = false;
        public static bool sacrificeForChicPick = false;

        public AudioSource bonusTime;
        public AudioSource chickenSacrificed;
        private bool soundIsPlay = false;

        ParticleSystem ps;

        public GameObject bonusTimeUI;
        private bool bonusTimeUIBool = false;

        void Update()
        {
            ps = GameObject.Find("Particle Sacrifice").GetComponent<ParticleSystem>();

            PlayScoreUI();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC" && soundIsPlay == false)
            {
                bonusTimeUIBool = true;
                sacrificeForChicPick = true;
                sacrificedForReal = true;
                Destroy(other.gameObject);
                Debug.Log("Chicken is sacrificed");
                sacrificed = true;
                PlaySound();
                PlayParticles();
                soundIsPlay = false;
            }
        }

        void PlaySound()
        {
            bonusTime.Play();
            chickenSacrificed.Play();
            soundIsPlay = true;
        }

        void PlayParticles()
        {
            ps.Play();
        }

        void PlayScoreUI()
        {
            if (bonusTimeUIBool == true)
            {
                /*Instantiate(bonusTimeUI, transform.position, transform.rotation *= Quaternion.Euler(0, 90, 0));
                //StartCoroutine(WaitBeforeDestroyUI());
                bonusTimeUIBool = false;*/
                GameObject clone = (GameObject)Instantiate(bonusTimeUI, transform.position, Quaternion.identity);
                Destroy(clone, 2.0f);
                bonusTimeUIBool = false;
            }
        }
    }
}

