using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivateJoy : MonoBehaviour
{
    public TCKButton ActivateJoystick;
    public TCKButton pickBtn;
    public TCKButton unpickBtn;
    public TCKButton ActivateSeed;
    public TCKButton spawnSeedBtn;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        ActivateJoystick = GameObject.Find("ActivateJoystick").GetComponent<TCKButton>();
        /*ActivateJoystick.isEnable = true;*/
        pickBtn = GameObject.Find("pickBtn").GetComponent<TCKButton>();
        pickBtn.isEnable = false;
        unpickBtn = GameObject.Find("unpickBtn").GetComponent<TCKButton>();
        unpickBtn.isEnable = false;
        ActivateSeed = GameObject.Find("ActivateSeed").GetComponent<TCKButton>();
        ActivateSeed.isEnable = false;
        spawnSeedBtn = GameObject.Find("spawnSeedBtn").GetComponent<TCKButton>();
        spawnSeedBtn.isEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivateJoystick", EActionEvent.Click))
        {
            click.Play();
            ActivateJoystick.isEnable = false;
            //pickBtn.isEnable = true;
            spawnSeedBtn.isEnable = true;
            //unpickBtn.isEnable = true;
            ActivateSeed.isEnable = true;
        }
    }

}
