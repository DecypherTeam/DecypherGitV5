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

        EndPos endPos;

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnenemy = GameObject.Find("SpawnEnemy");
            spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();

            GameObject hand = GameObject.Find("EndPos");
            endPos = hand.GetComponent<EndPos>();
        }

        // Update is called once per frame
        void Update()
        {
            
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

