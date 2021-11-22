using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIndicator : MonoBehaviour
{
    private GameObject[] indicatorUI;

    void Start()
    {

    }

    void Update()
    {
        indicatorUI = GameObject.FindGameObjectsWithTag("IndicatorUI");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            indicatorUI[0].SetActive(false);
        }
    }
}
