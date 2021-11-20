using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class SpawnEnemy : MonoBehaviour
    {
        public GameObject enemy;

        EnemyController enemyController;

        public bool enemySpawn;

        public AudioSource boarComingSound;

        public GameObject[] enemyCheck;
        public GameObject[] ghostCheck;
        private bool playMusic = false;

        private int count = 0;

        public GameObject warningSign;

        void Start()
        {
            warningSign.SetActive(false);
        }

        void Update()
        {
            SpawnEnemies();

            //PlayMusic();

            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            ghostCheck = GameObject.FindGameObjectsWithTag("Ghost");
            if (enemyCheck.Length == 0 && ghostCheck.Length == 0 || EnemyController.goHome == true)
            {
                warningSign.SetActive(false);
                boarComingSound.Pause();
                count = 0;
            }
            else if(enemyCheck.Length != 0 && EnemyController.goHome == false)
            {
                count++;
                if (count <= 1)
                {
                    warningSign.SetActive(true);
                    playMusic = true;
                    PlayMusic();
                    print("is playing");
                }
            }
        }

        void SpawnEnemies()
        {
            if (enemySpawn == true)
            {
                warningSign.SetActive(true);
                boarComingSound.Play();
                Instantiate(enemy, transform.position, transform.rotation);
                enemySpawn = false;
            }

            /*if (EnemyController.goHome == false)
            {
                playMusic = true;
                PlayMusic();
                print("Enemy not going home");
            }*/
        }

        void PlayMusic()
        {
            if (playMusic == true)
            {
                boarComingSound.Play();
                playMusic = false;
            }   
        }
    }
}

