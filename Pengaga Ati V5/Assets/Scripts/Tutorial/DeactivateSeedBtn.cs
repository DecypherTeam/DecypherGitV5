using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivateSeedBtn : MonoBehaviour
{
    public TCKButton ActivateSeed;
    public TCKButton ActivatePlant;
    public TCKButton spawnSeedBtn;

    public AudioSource click;

    private bool buttonClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSeed = GameObject.Find("ActivateSeed").GetComponent<TCKButton>();
        //ActivateSeed.isEnable = true;
        ActivatePlant = GameObject.Find("ActivatePlant").GetComponent<TCKButton>();
        ActivatePlant.isEnable = false;
        spawnSeedBtn = GameObject.Find("spawnSeedBtn").GetComponent<TCKButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(TCKInput.GetAction("spawnSeedBtn", EActionEvent.Click))
        {
            buttonClicked = true;
        }

        if (TCKInput.GetAction("ActivateSeed", EActionEvent.Click) && buttonClicked == true)
        {
            click.Play();
            ActivateSeed.isEnable = false;
            ActivatePlant.isEnable = true;
        }
    }

}
