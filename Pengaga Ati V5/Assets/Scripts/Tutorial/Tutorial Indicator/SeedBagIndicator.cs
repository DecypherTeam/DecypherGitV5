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
            StartCoroutine(SpawnUI());
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        IEnumerator SpawnUI()
        {
            yield return new WaitForSeconds(1);
            Vector3 pos = new Vector3(0f, 0.5f, 0f);
            Instantiate(indicator, transform.position + pos, transform.rotation);
        }
    }
}
