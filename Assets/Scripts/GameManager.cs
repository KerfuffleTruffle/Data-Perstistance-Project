using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public string PlayerName;
    public int PlayerScore;
    public string HighScoreName;
    public int HighScore;
    public List<PlayerData> HighScoreList = new List<PlayerData>();

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    public class PlayerData {
        public string name;
        public int score;

        public PlayerData(string playerName, int playerScore) {
            name = playerName;
            score = playerScore;
        }
    }

    [System.Serializable]
    class SaveData {
        public List<PlayerData> players;
    }

    public void SaveHighScore() {
        SaveData data = new SaveData();
        data.players = HighScoreList;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreList = data.players;
        }
    }
}
