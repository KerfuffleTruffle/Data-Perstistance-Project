using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class StartMenuUIHandler : MonoBehaviour {

    public TMP_InputField playerNameInput;
    public GameObject warningText;
    
    private void Start() {
        if (GameManager.Instance != null) {
            playerNameInput.text = GameManager.Instance.PlayerName;
        }
    }

    public void UpdatePlayerName() {
        GameManager.Instance.PlayerName = playerNameInput.text;
        if (warningText.gameObject.activeSelf) {
            warningText.SetActive(false);
        }
    }

    public void StartNew() {
        if (!string.IsNullOrEmpty(GameManager.Instance.PlayerName)) {
            Debug.Log("name: " + GameManager.Instance.PlayerName);
            SceneManager.LoadScene(1);
        } else {
            warningText.SetActive(true);
            Debug.Log("no name");
        }
    }

    public void Exit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else 
            Application.Quit();
        #endif
    }

    public void GotoHighScoreScene() {
        SceneManager.LoadScene(2);
    }
}
