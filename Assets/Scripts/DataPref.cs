using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataPref : MonoBehaviour
{
    public static DataPref Instance;

    public string currentPlayerName;

    public string playerName;
    

    public int highScore;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Rendering.DebugManager.instance.enableRuntimeUI = false;
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadPlayerData();
    }

    // Load data from saved files
    private void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            highScore = data.highScore;
        }
    }

    // save data to saved files
    public void SavePlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        SaveData data = new()
        {
            playerName = playerName,
            highScore = highScore,
        };

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(path, json);
    }

    [Serializable]
    public class SaveData
    {
        public string playerName;
        public int highScore;
    }
}
