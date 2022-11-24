using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI inputField;

    public TextMeshProUGUI BestScoreText;

    private void Start()
    {
        if (!string.IsNullOrEmpty(DataPref.Instance.playerName))
            BestScoreText.text = "Best Score: Player Name - " + DataPref.Instance.playerName + " Score - " + DataPref.Instance.highScore;
        else 
            BestScoreText.text = "Best Score: ";
    }

    public void StartNewGame()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        DataPref.Instance.currentPlayerName = inputField.text;
    }
}
