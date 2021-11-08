using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivatepickupBtn : MonoBehaviour
{
    public TCKButton ActivatePickup;
    public TCKButton ActivateSeed;
    public TCKButton spawnSeedBtn;

    // Start is called before the first frame update
    void Start()
    {
        ActivatePickup = GameObject.Find("ActivatePickup").GetComponent<TCKButton>();
        ActivatePickup.isEnable = true;
        ActivateSeed = GameObject.Find("ActivateSeed").GetComponent<TCKButton>();
        ActivateSeed.isEnable = false;
        spawnSeedBtn = GameObject.Find("spawnSeedBtn").GetComponent<TCKButton>();
        spawnSeedBtn.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivatePickup", EActionEvent.Click))
        {
            ActivatePickup.isEnable = false;
            ActivateSeed.isEnable = true;
            spawnSeedBtn.isEnable = true;
        }
    }

}
