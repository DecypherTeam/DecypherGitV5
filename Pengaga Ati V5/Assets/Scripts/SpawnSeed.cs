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

        void Update()
        {
            if (TCKInput.GetAction("spawnSeedBtn", EActionEvent.Down))
            {
                SpawnChillieSeed();
            }
        }

        void SpawnChillieSeed()
        {
            Instantiate(chillieSeed, transform.position, transform.rotation); 
        }
    }
}

