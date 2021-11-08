using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class uiObjectseconds : MonoBehaviour
{
    public GameObject UIshown;
    // Start is called before the first frame update
    void Start()
    {
        UIshown.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UIshown.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }
    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Destroy(UIshown);
        Destroy(gameObject);
    }
}
