using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivateTut : MonoBehaviour
{
    public TCKButton ActivateTutorial;
    public TCKButton ActivateJoystick;

    // Start is called before the first frame update
    void Start()
    {
        ActivateTutorial = GameObject.Find("ActivateTutorial").GetComponent<TCKButton>();
        ActivateTutorial.isEnable = true;
        ActivateJoystick = GameObject.Find("ActivateJoystick").GetComponent<TCKButton>();
        ActivateJoystick.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivateTutorial", EActionEvent.Click))
        {
            ActivateTutorial.isEnable = false;
            ActivateJoystick.isEnable = true;
        }
    }

}
