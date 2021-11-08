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

        void Update()
        {
            SpawnEnemies();

            //PlayMusic();

            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            ghostCheck = GameObject.FindGameObjectsWithTag("Ghost");
            if (enemyCheck.Length == 0 && ghostCheck.Length == 0)
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
        }

        void PlayMusic()
        {
            if (playMusic == true)
            {
                boarComingSound.Play();
            } 
        }
    }
}

