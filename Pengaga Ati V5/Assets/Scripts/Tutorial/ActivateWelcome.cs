using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivateWelcome : MonoBehaviour
{
    public TCKButton WelcomeTutorial;
    public TCKButton ActivateTutorial;

    // Start is called before the first frame update
    void Start()
    {
        WelcomeTutorial = GameObject.Find("WelcomeTutorial").GetComponent<TCKButton>();
        WelcomeTutorial.isEnable = true;
        ActivateTutorial = GameObject.Find("ActivateTutorial").GetComponent<TCKButton>();
        ActivateTutorial.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("WelcomeTutorial", EActionEvent.Click))
        {
            WelcomeTutorial.isEnable = false;
            ActivateTutorial.isEnable = true;
        }
    }

}
