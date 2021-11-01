using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plant")
        {
            Destroy(other.gameObject);
            Debug.Log("Chillie is successfully delivered");
            ScoringSystem.theScore += 1;
        }
    }
}
