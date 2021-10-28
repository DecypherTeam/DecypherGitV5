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

        // Start is called before the first frame update
        void Start()
        {
            GameObject spawnenemy = GameObject.Find("SpawnEnemy");
            spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Chillie SeedBag")
            {
                Player.carryObject = false;
                Destroy(other.gameObject);
                spawnplant();
            }
        }

        void spawnplant()
        {
            Instantiate(chillie, transform.position, transform.rotation);
            enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            
            if(enemyCheck.Length == 0)
            {
                spawnEnemy.enemySpawn = true;
            }
            
        }
    }
}

