using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class AltarScript : MonoBehaviour
    {
        public static bool sacrificed = false;

        public AudioSource bonusTime;
        public AudioSource chickenSacrificed;
        private bool soundIsPlay = false;

        ParticleSystem ps;

        ChickenPickUp chicken;

        void Start()
        {
            GameObject chic = GameObject.Find("Chicken");
            chicken = chic.GetComponent<ChickenPickUp>();
        }

        void Update()
        {
            ps = GameObject.Find("Particle Sacrifice").GetComponent<ParticleSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC")
            {
                //chicken.ActivatePickBtn();
                ChickenPickUp.chickenGone = true;
                sacrificed = true;
                Destroy(other.gameObject);
                Debug.Log("Chicken is sacrificed");
                PlaySound();
                PlayParticles();
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

