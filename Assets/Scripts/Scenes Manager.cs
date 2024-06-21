using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    [SerializeField] private GameObject panel; 
    private Scene scene;
    private int maxScenes;
    private int currentSceneNumber = 1; // Define the number of the starting scene

    void Awake() {
        maxScenes = SceneManager.sceneCountInBuildSettings; // Count the number of scenes in the build project
        Debug.Log(maxScenes);

        SwitchScene(currentSceneNumber); // Initialize the first scene where we has to begin
    }

    void Start() {
        
    }

    void Update() {
        test();
    }

    //TODO: will be different when the frag code will be implemented
    void test() {
        if(panel.tag == "Next") {
            currentSceneNumber = currentSceneNumber + 1;
            SwitchScene(currentSceneNumber);
            panel.tag = "Untagged";
        }
    }

    // Call the number of the scene to load in addition of the main scene
    Scene SwitchScene(int sceneNumber) {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);

        if(currentSceneNumber <= maxScenes - 1) {
            scene = SceneManager.LoadScene(sceneNumber, parameters);
            SceneManager.UnloadSceneAsync(sceneNumber - 1);
        } else {
            scene = SceneManager.LoadScene(1, parameters);
            SceneManager.UnloadSceneAsync(maxScenes - 1);
        }

        Debug.Log("scene " + scene.name + " loaded");
        return scene;

    }
}
