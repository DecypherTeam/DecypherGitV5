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

        private bool changePosition = false;

        public static bool handInPosition = false;
        private bool positionHere = false;

        void Start()
        {
            
        }

        void Update()
        {
            if (plantScript.seedPlanted == true)
            {
                changePosition = true;
            }

            if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Press))
            {
                if(changePosition == true && positionHere == true)
                {
                    rightHand.position = transform.position;
                    handInPosition = true;
                    print("hand is in position");
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
                print("touched plant");
                positionHere = true;
            }
        }


        /*void ChangePosition()
        {
            if(plantScript.seedPlanted == true)
            {
                changePosition = true;
            }
        }*/
    }
}

