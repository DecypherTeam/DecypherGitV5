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

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "NPC" && soundIsPlay == false)
            {
                Destroy(other.gameObject);
                Debug.Log("Chicken is sacrificed");
                sacrificed = true;
                PlaySound();
                soundIsPlay = false;
            }
        }

        void PlaySound()
        {
            bonusTime.Play();
            chickenSacrificed.Play();
            soundIsPlay = true;
        }
    }
}

