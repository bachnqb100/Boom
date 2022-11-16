using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip start;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TwoPlayer()
    {
        SceneManager.LoadScene("MultiPlayer");
        audioSource.PlayOneShot(start, 0.5f);
    }

    public void PlayAI()
    {
        audioSource.PlayOneShot(start, 0.5f);
    }

    public void Quit()
    {
        audioSource.PlayOneShot(start, 0.5f);
        Application.Quit();
    }
}
