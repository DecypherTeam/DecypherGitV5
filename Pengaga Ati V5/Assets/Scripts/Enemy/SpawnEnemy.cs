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

        void Start()
        {
            
        }

        void Update()
        {
             SpawnEnemies();
        }

        void SpawnEnemies()
        {
            if (enemySpawn == true)
            {
                Instantiate(enemy, transform.position, transform.rotation);
                enemySpawn = false;
            }
        }
    }
}

