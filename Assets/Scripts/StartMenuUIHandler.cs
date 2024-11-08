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
    
    private void Start() {
        if (GameManager.Instance != null) {
            playerNameInput.text = GameManager.Instance.PlayerName;
        }
    }

    public void UpdatePlayerName() {
        GameManager.Instance.PlayerName = playerNameInput.text;
    }

      public void StartNew() {
        if (GameManager.Instance != null) {
            Debug.Log("name: " + GameManager.Instance.PlayerName);
            SceneManager.LoadScene(1);
        }
        Debug.Log("no name");
    }

    public void Exit(){
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else 
            Application.Quite();
        #endif
    }
}
