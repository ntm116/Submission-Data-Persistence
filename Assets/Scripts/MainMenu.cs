using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI inputField;

    public void StartNewGame()
    {
        SaveData();
        SceneManager.LoadScene(1);
    }

    public void SaveData()
    {
        DataPref.Instance.playerName = inputField.text;
    }
}
