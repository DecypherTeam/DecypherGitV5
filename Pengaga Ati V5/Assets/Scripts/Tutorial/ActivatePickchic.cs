using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivatePickchic : MonoBehaviour
{
    public TCKButton ActivateSpirit;
    public TCKButton ActivateTimer;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSpirit = GameObject.Find("ActivateSpirit").GetComponent<TCKButton>();
        ActivateSpirit.isEnable = true;
        ActivateTimer = GameObject.Find("ActivateTimer").GetComponent<TCKButton>();
        ActivateTimer.isEnable = false;

    }

    void Update()
    {
        //the dialogue box for the specific button setActive is equal to true)
        if (TCKInput.GetAction("ActivateSpirit", EActionEvent.Click))
        {
            ActivateSpirit.isEnable = false;
            ActivateTimer.isEnable = true;
        }
    }
}