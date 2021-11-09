using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;


namespace Examples { 
public class DestroySpiritTutorial : MonoBehaviour
    {
        public GameObject spiritCheck;
        public GameObject timer;
        public GameObject scoreboard;
        public GameObject scorebg;

        public ParticleSystem ps;

        public AudioSource windSound;

        private void Start()
        {
            timer.SetActive(false);
            scoreboard.SetActive(false);
            scorebg.SetActive(false);
        }

        void Update()
        {
            spiritCheck = GameObject.FindGameObjectWithTag("Ghost");

            if (TCKInput.GetAction("killSpiritBtn", EActionEvent.Press))
            {
                
                if (spiritCheck)
                {
                    //transform.position = GameObject[] spiritCheck.transform.position;
                    EnemyControllerTutorial.destroy = true;
                    ps.Play();
                    windSound.Play();
                    timer.SetActive(true);
                    scoreboard.SetActive(true);
                    scorebg.SetActive(true);
                }
            }
        }
    }
}