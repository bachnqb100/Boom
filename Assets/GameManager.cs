using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] players;
    public GameObject gameOverMenu;
    public static string winner;

    private AudioSource audioXX;
    public AudioClip buttonAudio;

    private int alive;

    private bool gameOver = false;

    private void Awake()
    {
        alive = players.Length;
        audioXX = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (gameOver) return;

        foreach (var player in players)
        {
            if (!player.activeSelf)
            {
                alive--;
            }
        }

        if (alive <= 1)
        {
            foreach (var player in players)
            {
                if (player.activeSelf)
                {
                    winner = player.name;
                }
            }

            gameOver = true;
            gameOverMenu.SetActive(true);
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over");
    }

    public void RePlay()
    {
        audioXX.PlayOneShot(buttonAudio);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        audioXX.PlayOneShot(buttonAudio);
        SceneManager.LoadScene("Menu");
    }
}
