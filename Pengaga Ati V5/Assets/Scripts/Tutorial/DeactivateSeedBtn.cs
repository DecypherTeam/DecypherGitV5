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
    public TCKButton pickBtn;
    public TCKButton unpickBtn;

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
        pickBtn = GameObject.Find("pickBtn").GetComponent<TCKButton>();
        pickBtn.isEnable = false;
        unpickBtn = GameObject.Find("unpickBtn").GetComponent<TCKButton>();
        unpickBtn.isEnable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(TCKInput.GetAction("spawnSeedBtn", EActionEvent.Click))
        {
            buttonClicked = true;
        }

        if (/*TCKInput.GetAction("ActivateSeed", EActionEvent.Click) &&*/ buttonClicked == true)
        {
            click.Play();
            pickBtn.isEnable = true;
            unpickBtn.isEnable = true;
            ActivateSeed.isEnable = false;
            ActivatePlant.isEnable = true;
            buttonClicked = false;
        }
    }
}
