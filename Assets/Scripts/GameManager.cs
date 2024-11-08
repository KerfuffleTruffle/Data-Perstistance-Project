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
        SortSaveList();
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
            // Set highest score for easy comparison
            if (HighScoreList.Count > 0) {
                PlayerData highestScore = HighScoreList[0];
                HighScoreName = highestScore.name;
                HighScore = highestScore.score;
            }
        }
    }

    // Sorts the list in Descending order and restricts number of players included
    public void SortSaveList() {
        HighScoreList.Add(new PlayerData(PlayerName, PlayerScore));
        
        // Sort list so we can load highest score easily
        HighScoreList.Sort((player1, player2) => player2.score.CompareTo(player1.score));

        // Restrict amount of players in list 
        if (HighScoreList.Count > 5) {
            HighScoreList = HighScoreList.GetRange(0, 5);
        }
    }

}
