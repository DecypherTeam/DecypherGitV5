using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiObject : MonoBehaviour
{
    public GameObject showUI;
    // Start is called before the first frame update
    void Start()
    {
        showUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            showUI.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(20);
        Destroy(showUI);
        Destroy(gameObject);
    }
}
