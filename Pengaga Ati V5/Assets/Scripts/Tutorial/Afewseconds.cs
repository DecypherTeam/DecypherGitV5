using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Afewseconds : MonoBehaviour
{
    public GameObject First = null;
    public GameObject Second = null;

    public void Start()
    {
        First.SetActive(false);
        Second.SetActive(false);

        //ShowCharacters();

        StartCoroutine(WaitBeforeShow());
    }

    private void ShowCharacters()
    {
        First.SetActive(true);

        //wait a couple of seconds

        Second.SetActive(true);
    }

    private IEnumerator WaitBeforeShow()
    {
        First.SetActive(true);

        yield return new WaitForSeconds(20);

        Second.SetActive(true);
    }

}
