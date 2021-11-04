using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class DestroySpirit : MonoBehaviour
    {
        public GameObject[] spiritCheck;

        public ParticleSystem ps;

        void Update()
        {
            spiritCheck = GameObject.FindGameObjectsWithTag("Ghost");

            if (TCKInput.GetAction("killSpiritBtn", EActionEvent.Press))
            {
                if (spiritCheck.Length != 0)
                {
                    //transform.position = GameObject[] spiritCheck.transform.position;
                    EnemyController.destroy = true;
                    ps.Play();
                }
            }
        }
    }
}

