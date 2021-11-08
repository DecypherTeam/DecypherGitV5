using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivateKillchic : MonoBehaviour
{
    public TCKButton ActivateTimer;
    public TCKButton ActivateSacrifice;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        ActivateTimer = GameObject.Find("ActivateTimer").GetComponent<TCKButton>();
        //ActivateTimer.isEnable = true;
        ActivateSacrifice = GameObject.Find("ActivateSacrifice").GetComponent<TCKButton>();
        ActivateSacrifice.isEnable = false;

    }

    void Update()
    {
        //the dialogue box for the specific button setActive is equal to true)
        if (TCKInput.GetAction("ActivateTimer", EActionEvent.Click))
        {
            click.Play();
            ActivateTimer.isEnable = false;
            ActivateSacrifice.isEnable = true;
        }
    }
}
