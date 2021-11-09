using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

namespace Examples {
    public class DeactivateShootBtn : MonoBehaviour
    {
        public TCKButton ActivateWildBoar;
        public TCKButton ActivateRain;
        public TCKButton fireBtn;
        public TCKButton plantSeedBtn;

        public AudioSource click;

        //private bool isClicked = false;

        // Start is called before the first frame update
        void Start()
        {
            ActivateRain = GameObject.Find("ActivateRain").GetComponent<TCKButton>();
            //ActivateRain.isEnable = true;
            ActivateWildBoar = GameObject.Find("ActivateWildBoar").GetComponent<TCKButton>();
            ActivateWildBoar.isEnable = false;
            fireBtn = GameObject.Find("fireBtn").GetComponent<TCKButton>();
            fireBtn.isEnable = false;
            plantSeedBtn = GameObject.Find("plantSeedBtn").GetComponent<TCKButton>();
        }

        // Update is called once per frame
        void Update()
        {
            /*if (TCKInput.GetAction("plantSeedBtn", EActionEvent.Press))
            {
                isClicked = true;
            }*/

            if (TCKInput.GetAction("ActivateRain", EActionEvent.Click) && /*isClicked == true*/ Growth.isHarvested == true)
            {
                click.Play();
                ActivateRain.isEnable = false;
                fireBtn.isEnable = true;
                ActivateWildBoar.isEnable = true;
                Growth.isHarvested = false;
            }
        }
    }
}
