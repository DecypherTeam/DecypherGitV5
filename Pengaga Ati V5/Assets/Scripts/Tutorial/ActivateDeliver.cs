using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

namespace Examples
{
    public class ActivateDeliver : MonoBehaviour
    {
        public TCKButton ActivateTimer;
        public TCKButton ActivateSacrifice;
        public TCKButton ActivateDelivery;

        public AudioSource click;

        // Start is called before the first frame update
        void Start()
        {
            ActivateSacrifice = GameObject.Find("ActivateSacrifice").GetComponent<TCKButton>();
            //ActivateSacrifice.isEnable = true;
            ActivateDelivery = GameObject.Find("ActivateDelivery").GetComponent<TCKButton>();
            ActivateDelivery.isEnable = false;
            ActivateTimer = GameObject.Find("ActivateTimer").GetComponent<TCKButton>();
            ActivateTimer.isEnable = false;
        }

        void Update()
        {
            //the dialogue box for the specific button setActive is equal to true)
            if (TCKInput.GetAction("ActivateSacrifice", EActionEvent.Click) && AltarScript.sacrificedForReal == true)
            {
                click.Play();
                ActivateSacrifice.isEnable = false;
                ActivateDelivery.isEnable = true;
                AltarScript.sacrificedForReal = false;
            }
        }
    }
}
