using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class StartMenuUI : MonoBehaviour
{
    public GameManager GameManager;

    void Start() {
       // GameManager.Init();
    }

    public void StartNew() {
        SceneManager.LoadScene(1);
    }

    public void Exit(){

    }

}
