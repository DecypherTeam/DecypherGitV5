using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Examples
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject goalMenu;
        [SerializeField] GameObject score;
        [SerializeField] GameObject timer;

        public AudioSource click;

        public static bool startTime = false;

        public void Pause()
        {
            click.Play();
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            click.Play();
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Home(int sceneID)
        {
            click.Play();
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneID);
        }

        public void Settings(int sceneID)
        {
            click.Play();
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneID);
        }

        public void Play()
        {
            click.Play();
            goalMenu.SetActive(false);
            score.SetActive(true);
            timer.SetActive(true);
            startTime = true;
        }

        public void Restart(int sceneID)
        {
            click.Play();
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneID);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
