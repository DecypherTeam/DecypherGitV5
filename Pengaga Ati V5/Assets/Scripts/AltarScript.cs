using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class AltarScript : MonoBehaviour
    {
        public static bool sacrificed = false;

        public static bool sacrificedForReal = false;

        public AudioSource bonusTime;
        public AudioSource chickenSacrificed;
        private bool soundIsPlay = false;

        ParticleSystem ps;

        void Update()
        {
            ps = GameObject.Find("Particle Sacrifice").GetComponent<ParticleSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC" && soundIsPlay == false)
            {
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
    }
}

