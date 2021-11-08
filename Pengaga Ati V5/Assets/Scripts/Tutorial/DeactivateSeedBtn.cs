using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TouchControlsKit;

public class DeactivateSeedBtn : MonoBehaviour
{
    public TCKButton ActivateSeed;
    public TCKButton ActivatePlant;

    // Start is called before the first frame update
    void Start()
    {
        ActivateSeed = GameObject.Find("ActivateSeed").GetComponent<TCKButton>();
        ActivateSeed.isEnable = true;
        ActivatePlant = GameObject.Find("ActivatePlant").GetComponent<TCKButton>();
        ActivatePlant.isEnable = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (TCKInput.GetAction("ActivateSeed", EActionEvent.Click))
        {
            ActivateSeed.isEnable = false;
            ActivatePlant.isEnable = true;
        }
    }

}
