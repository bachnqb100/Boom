using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI winnertext;

    private void Awake()
    {
        winnertext.text = GameManager.winner;
    }
}
