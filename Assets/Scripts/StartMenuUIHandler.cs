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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayerName() {
       // GameManager.Instance.PlayerName = playerNameInput.text;
    }

      public void StartNew() {
        if (GameManager.Instance.PlayerName != null) {
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
