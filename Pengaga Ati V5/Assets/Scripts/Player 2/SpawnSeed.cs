using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class SpawnSeed : MonoBehaviour
    {
        public GameObject chillieSeed;

        public bool chillieSeedSpawn;

        public GameObject[] seedCheck;

        void Update()
        {
            if (TCKInput.GetAction("spawnSeedBtn", EActionEvent.Down))
            {
                SpawnChillieSeed();
            }
        }

        void SpawnChillieSeed()
        {
            seedCheck = GameObject.FindGameObjectsWithTag("Chillie SeedBag");
            if(seedCheck.Length == 1)
            {
                Instantiate(chillieSeed, transform.position, transform.rotation);
            }  
        }
    }
}

