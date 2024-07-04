using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Init : MonoBehaviour
{
    internal string previousSceneLoaded;

    void Awake() {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        SceneManager.LoadScene(1, parameters);
    }

    void Start() {
        previousSceneLoaded = "Start";
        Debug.Log("previous scene: " + previousSceneLoaded);
    }

    void Update() {
        
    }
}
