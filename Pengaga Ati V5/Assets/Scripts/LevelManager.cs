using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public AudioSource clickNext;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadNextLevel(string LevelName)
    {
        clickNext.Play();
        Application.LoadLevel(LevelName);
        Time.timeScale = 1;
    }
}