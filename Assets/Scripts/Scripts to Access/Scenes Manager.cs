using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    void Awake() {
    }

    void Start() {
    }

    void Update() {
    }

    // Call the number of the scene to load in addition of the main scene
    public void SwitchScene(int sceneNumber) {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        
        SceneManager.LoadScene(sceneNumber, parameters);
        SceneManager.UnloadSceneAsync(sceneNumber - 1);

        Debug.Log("scene " + SceneManager.LoadScene(sceneNumber, parameters).name + " loaded");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
