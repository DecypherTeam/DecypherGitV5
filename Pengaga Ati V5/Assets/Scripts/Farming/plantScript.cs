using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class plantScript : MonoBehaviour
    {
        public GameObject chillie;

        SpawnEnemy spawnEnemy;

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
                Destroy(other.gameObject);
                spawnplant();
            }
        }

        void spawnplant()
        {
            Instantiate(chillie, transform.position, transform.rotation);
            spawnEnemy.enemySpawn = true;
        }
    }
}

