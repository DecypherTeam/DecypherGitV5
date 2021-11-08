using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivateDeliver : MonoBehaviour
{
    public TCKButton ActivateSacrifice;
    public TCKButton ActivateDelivery;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSacrifice = GameObject.Find("ActivateSacrifice").GetComponent<TCKButton>();
        ActivateSacrifice.isEnable = true;
        ActivateDelivery = GameObject.Find("ActivateDelivery").GetComponent<TCKButton>();
        ActivateDelivery.isEnable = false;

    }

    void Update()
    {
        //the dialogue box for the specific button setActive is equal to true)
        if (TCKInput.GetAction("ActivateSacrifice", EActionEvent.Click))
        {
            ActivateSacrifice.isEnable = false;
            ActivateDelivery.isEnable = true;
        }
    }
}
