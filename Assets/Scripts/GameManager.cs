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
    //public HighScoreList highscores;

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
    class SaveData {
        public string name;
        public int highscore;
    }

    public void SaveHighScore() {
        if (PlayerScore >= HighScore)
        {
            SaveData data = new SaveData();
            data.name = PlayerName;
            data.highscore = PlayerScore;

            string json = JsonUtility.ToJson(data);

            File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        }
    }

    public void LoadData() {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScoreName = data.name;
            HighScore = data.highscore;
        }
    }
}
