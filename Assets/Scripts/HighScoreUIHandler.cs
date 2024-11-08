using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreUIHandler : MonoBehaviour
{
    public TextMeshProUGUI leaderBoardText;
    public TextMeshProUGUI leaderBoardPosition;
    public TextMeshProUGUI leaderBoardName;
    public TextMeshProUGUI leaderBoardScore;
    void Start(){
        PrintLeaderBoard();
    }

    public void Back() {
        SceneManager.LoadScene(0);
    }

    private void PrintLeaderBoard() {
        if (GameManager.Instance == null) {
            leaderBoardText.text = "NO GAME MANAGER DETECTED";
        } else {
            if (GameManager.Instance.HighScoreList.Count > 0){
                int i = 1;
                foreach (var player in GameManager.Instance.HighScoreList) {
                    leaderBoardPosition.text += $"{i}\n";
                    leaderBoardName.text += $"{player.name}\n";
                    leaderBoardScore.text += $"{player.score}\n";
                    i++;
                }
            } else {
                leaderBoardText.text = "List Empty";
            }
        }
    }
}
