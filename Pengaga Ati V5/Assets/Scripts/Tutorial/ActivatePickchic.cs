using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class ActivatePickchic : MonoBehaviour
{
    public TCKButton ActivateSpirit;
    public TCKButton ActivateTimer;

    public AudioSource click;

    public TCKButton killSpiritBtn;

    private bool isClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSpirit = GameObject.Find("ActivateSpirit").GetComponent<TCKButton>();
        //ActivateSpirit.isEnable = true;
        ActivateTimer = GameObject.Find("ActivateTimer").GetComponent<TCKButton>();
        ActivateTimer.isEnable = false;
        killSpiritBtn = GameObject.Find("killSpiritBtn").GetComponent<TCKButton>();
    }

    void Update()
    {
        if (TCKInput.GetAction("killSpiritBtn", EActionEvent.Click))
        {
            isClicked = true;
        }

            //the dialogue box for the specific button setActive is equal to true)
        if (isClicked == true)
        {
            click.Play();
            ActivateSpirit.isEnable = false;
            ActivateTimer.isEnable = true;
            isClicked = false;
        }
    }
}