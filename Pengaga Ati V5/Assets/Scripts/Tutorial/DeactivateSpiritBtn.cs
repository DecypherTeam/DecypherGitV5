using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivateSpiritBtn : MonoBehaviour
{
    public TCKButton ActivateWildBoar;
    public TCKButton killSpiritBtn;
    public TCKButton ActivateSpirit;
    public TCKButton ActivateTutorial;

    public AudioSource click;

    // Start is called before the first frame update
    void Start()
    {
        ActivateWildBoar = GameObject.Find("ActivateWildBoar").GetComponent<TCKButton>();
        //ActivateWildBoar.isEnable = true;
        ActivateSpirit = GameObject.Find("ActivateSpirit").GetComponent<TCKButton>();
        ActivateSpirit.isEnable = false;
        killSpiritBtn = GameObject.Find("killSpiritBtn").GetComponent<TCKButton>();
        killSpiritBtn.isEnable = false;
        ActivateTutorial = GameObject.Find("ActivateTutorial").GetComponent<TCKButton>();
    }

    void Update()
    {
        //the dialogue box for the specific button setActive is equal to true)
        if (TCKInput.GetAction("ActivateWildBoar", EActionEvent.Click))
        {
            click.Play();
            ActivateWildBoar.isEnable = false;
            ActivateTutorial.isEnable = false;
            killSpiritBtn.isEnable = true;
            ActivateSpirit.isEnable = true;
        }
    }
}
