using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Examples { 
public class ScoringPointTut : MonoBehaviour
{
    public GameObject winScreen;

    public AudioSource winSound;
    private bool winSoundIsPlay = false;

    public AudioSource deliveredSound;

    public static bool delivered = false;

    public GameObject deliveredBtn;

    public GameObject plusOne;

    void Update()
    {
        if (ScoringSystemTutorial.theScore == 1 && winSoundIsPlay == false)
        {
                deliveredBtn.SetActive(false);
            winScreen.SetActive(true);
            Time.timeScale = 0;
            PlaySound();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Plant")
        {
                PlayScoreUI();
            Destroy(other.gameObject);
            ScoringSystemTutorial.theScore += 1;
            deliveredSound.Play();
            delivered = true;
            Player.carryObject = false;
        }
    }

    void PlaySound()
    {
        winSound.Play();
        winSoundIsPlay = true;
    }

        void PlayScoreUI()
        {
            Instantiate(plusOne, transform.position, transform.rotation);
            StartCoroutine(WaitBeforeDestroyUI());
        }

        IEnumerator WaitBeforeDestroyUI()
        {
            yield return new WaitForSeconds(2);
            Destroy(plusOne);
        }
}
}
