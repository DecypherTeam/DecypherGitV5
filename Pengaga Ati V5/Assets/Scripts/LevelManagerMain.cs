using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerMain : MonoBehaviour
{
    public AudioSource clickNext;

    public void LoadNextLevel(string LevelName)
    {
        clickNext.Play();
        Application.LoadLevel(LevelName);
        Time.timeScale = 1;
    }
}
