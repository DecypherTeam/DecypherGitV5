using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class SeedBagIndicator : MonoBehaviour
    {
        public GameObject indicator;

        // Start is called before the first frame update
        void Start()
        {
            SpawnUI();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        void SpawnUI()
        {
            Vector3 pos = new Vector3(0f, 0.1f, 0f);
            Instantiate(indicator, transform.position + pos, transform.rotation);
        }
    }
}
