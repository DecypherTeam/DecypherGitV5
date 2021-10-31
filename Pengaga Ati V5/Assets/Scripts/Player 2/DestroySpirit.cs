using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class DestroySpirit : MonoBehaviour
    {
        public GameObject[] spiritCheck;

        void Start()
        {
            
        }

        void Update()
        {
            spiritCheck = GameObject.FindGameObjectsWithTag("Ghost");

            if (TCKInput.GetAction("killSpiritBtn", EActionEvent.Press))
            {
                if (spiritCheck.Length == 1)
                {
                    //transform.position = GameObject[] spiritCheck.transform.position;
                    EnemyController.destroy = true;
                }
            }
        }
    }
}

