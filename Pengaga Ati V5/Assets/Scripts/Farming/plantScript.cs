using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class plantScript : MonoBehaviour
    {
        public GameObject chillie;

        SpawnEnemy spawnEnemy;

        //public GameObject[] enemyCheck;

        public static bool seedPlanted = false;

        public static bool seedPlantedForReal = false;

        public bool handIsPlanting = false;

        public AudioSource planted;

        public bool canPlant = true;

        private GameObject[] checkPlant;

        
        void Start()
        {
            /*GameObject spawnenemy = GameObject.Find("SpawnEnemy");
            spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();*/
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Chillie SeedBag" && canPlant == true)
            {
                seedPlantedForReal = true;
                planted.Play();
                seedPlanted = true;
                Player.carryObject = false;
                Destroy(other.gameObject);
                spawnplant();
            }

            if(other.gameObject.tag == "Enemy")
            {
                canPlant = true;
                print("boar enter so canPlant is true");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                canPlant = true;
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Plant")
            {
                canPlant = false;
            }
            /*else
            {
                canPlant = true;
            }*/
        }

        public void spawnplant()
        {
            Instantiate(chillie, transform.position, transform.rotation);

            /*enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemyCheck.Length == 0)
            {
                spawnEnemy.enemySpawn = true;
            }*/
        }
    }
}

