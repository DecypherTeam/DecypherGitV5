using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class plantScript : MonoBehaviour
    {
        public GameObject chillie;

        SpawnEnemy spawnEnemy;

        public GameObject[] enemyCheck;

        public static bool seedPlanted = false;

        public bool handIsPlanting = false;

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnenemy = GameObject.Find("SpawnEnemy");
            spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Chillie SeedBag")
            {
                seedPlanted = true;
                Player.carryObject = false;
                Destroy(other.gameObject);
                spawnplant();
            }
        }

        public void spawnplant()
        {
            Instantiate(chillie, transform.position, transform.rotation);

            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemyCheck.Length == 0)
            {
                spawnEnemy.enemySpawn = true;
            }
        }
    }
}

