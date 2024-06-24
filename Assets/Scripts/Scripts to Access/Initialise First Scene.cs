using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialiseFirstScene : MonoBehaviour
{
    void Awake() {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        SceneManager.LoadScene(1, parameters);
    }

    void Start() {
        
    }

    void Update() {
        
    }
}
