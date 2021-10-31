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

        void Update()
        {
            if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Press))
            {
                if(positionHere == true && GrownCheck.plantIsGrown == false)
                {
                    rightHand.position = transform.position;
                    handInPosition = true;
                }    
            }
            
            if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Up))
            {
                rightHand.position = startPos.position;
                handInPosition = false;
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

