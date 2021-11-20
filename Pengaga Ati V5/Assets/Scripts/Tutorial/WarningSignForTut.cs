using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples
{
    public class WarningSignForTut : MonoBehaviour
    {
        public GameObject warningSign;

        // Start is called before the first frame update
        void Start()
        {
            warningSign.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if(EnemyControllerTutorial.boarOut == true)
            {
                warningSign.SetActive(true);
            }
            if(EnemyControllerTutorial.boarDie == true)
            {
                warningSign.SetActive(false);
            }
        }
    }
}
