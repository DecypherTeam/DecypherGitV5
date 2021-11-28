using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AudioSource clickNext;

    public Animator level1;

    void Start()
    {
        level1 = GameObject.Find("Level1").GetComponent<Animator>();
    }

    public void LoadNextLevel(string LevelName)
    {
        clickNext.Play();
        Application.LoadLevel(LevelName);
        Time.timeScale = 1;
    }

    public void SwitchNextLevel()
    {
        level1.SetBool("Switch", true);
    }
}