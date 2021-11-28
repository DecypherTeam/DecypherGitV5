using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AudioSource clickNext;

    public Animator level1;
    public Animator level2;
    public GameObject prevBtn;
    public GameObject nextBtn;

    public void LoadNextLevel(string LevelName)
    {
        clickNext.Play();
        Application.LoadLevel(LevelName);
        Time.timeScale = 1;
    }

    public void SwitchNextLevel()
    {
        level1.SetBool("Switch", true);
        level2.SetBool("Switch2", true);
        StartCoroutine(ShowPrevButton());
    }

    IEnumerator ShowPrevButton()
    {
        yield return new WaitForSeconds(0.5f);
        prevBtn.SetActive(true);
        nextBtn.SetActive(false);
    }

    public void SwitchPrevLevel()
    {
        level1.SetBool("Switch", false);
        level2.SetBool("Switch2", false);
        StartCoroutine(ShowNextButton());
    }

    IEnumerator ShowNextButton()
    {
        yield return new WaitForSeconds(0.5f);
        prevBtn.SetActive(false);
        nextBtn.SetActive(true);
    }
}