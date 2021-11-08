using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivateShootBtn : MonoBehaviour
{
    public TCKButton ActivateWildBoar;
    public TCKButton ActivateRain;
    public TCKButton fireBtn;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        ActivateRain = GameObject.Find("ActivateRain").GetComponent<TCKButton>();
        //ActivateRain.isEnable = true;
        ActivateWildBoar = GameObject.Find("ActivateWildBoar").GetComponent<TCKButton>();
        ActivateWildBoar.isEnable = false;
        fireBtn = GameObject.Find("fireBtn").GetComponent<TCKButton>();
        fireBtn.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivateRain", EActionEvent.Click))
        {
            click.Play();
            ActivateRain.isEnable = false;
            fireBtn.isEnable = true;
            ActivateWildBoar.isEnable = true;
        }
    }

}
