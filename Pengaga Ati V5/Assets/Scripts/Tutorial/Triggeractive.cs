using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Triggeractive : MonoBehaviour
{

    public GameObject Appear;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Appear.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
