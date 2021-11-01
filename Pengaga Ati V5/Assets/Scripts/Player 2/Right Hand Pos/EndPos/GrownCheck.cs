using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class GrownCheck : MonoBehaviour
    {
        public static bool plantIsGrown;

        SpawnEnemy spawnEnemy;

        public GameObject[] enemyCheck;

        private void Start()
        {
            GameObject spawnenemy = GameObject.Find("SpawnEnemy");
            spawnEnemy = spawnenemy.GetComponent<SpawnEnemy>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Plant")
            {
                print("Plant is fully grown");
                plantIsGrown = true;

                enemyCheck = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemyCheck.Length == 0)
                {
                    spawnEnemy.enemySpawn = true;
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                print("Plant is not fully grown");
                plantIsGrown = false;
            }
        }
    }
}
