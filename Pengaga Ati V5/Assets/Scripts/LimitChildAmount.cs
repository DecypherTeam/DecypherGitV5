using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitChildAmount : MonoBehaviour
{
    public int maxChildAmount = 1;
    
    void Update()
    {
        Transform[] children = new Transform[transform.childCount];

        for (int c = 0; c < children.Length; c++)
        {
            children[c] = transform.GetChild(c);
        }

        int iteration = 0;
        while (transform.childCount > 1)
        {
            children[iteration].SetParent(null);
            iteration++;
        }
    }
}
