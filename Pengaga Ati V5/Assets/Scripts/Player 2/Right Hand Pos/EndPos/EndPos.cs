using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class EndPos : MonoBehaviour
    {
        public Transform rightHand;
        public Transform startPos;

        public static bool handInPosition = false;

        private bool positionHere = false;

        public GameObject particles;

        void Update()
        {
            if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Press))
            {
                if(positionHere == true)
                {
                    rightHand.position = transform.position;
                    handInPosition = true;
                    particles.SetActive(true);
                }    
            }
            
            if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Up))
            {
                rightHand.position = startPos.position;
                handInPosition = false;
                particles.SetActive(false);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.tag == "Plant")
            {
                positionHere = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Plant")
            {
                positionHere = false;
            }
        }
    }
}

