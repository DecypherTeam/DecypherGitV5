using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivateRainBtn : MonoBehaviour
{
    public TCKButton ActivatePlant;
    public TCKButton ActivateRain;
    public TCKButton plantSeedBtn;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePlant = GameObject.Find("ActivatePlant").GetComponent<TCKButton>();
        //ActivatePlant.isEnable = true;
        ActivateRain = GameObject.Find("ActivateRain").GetComponent<TCKButton>();
        ActivateRain.isEnable = false;
        plantSeedBtn = GameObject.Find("plantSeedBtn").GetComponent<TCKButton>();
        plantSeedBtn.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivatePlant", EActionEvent.Click))
        {
            click.Play();
            ActivatePlant.isEnable = false;
            ActivateRain.isEnable = true;
            plantSeedBtn.isEnable = true;
        }
    }

}
