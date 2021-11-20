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

        void Update()
        {
            SpawnEnemies();

            //PlayMusic();

            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            ghostCheck = GameObject.FindGameObjectsWithTag("Ghost");
            if (enemyCheck.Length == 0 && ghostCheck.Length == 0 || EnemyController.goHome == true)
            {
                boarComingSound.Pause();
            }
        }

        void SpawnEnemies()
        {
            if (enemySpawn == true)
            {
                boarComingSound.Play();
                Instantiate(enemy, transform.position, transform.rotation);
                enemySpawn = false;
            }

            if(EnemyController.goHome == false)
            {
                PlayMusic();
            }
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

