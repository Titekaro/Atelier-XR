using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWristManager : MonoBehaviour
{
    [SerializeField] private GameObject wristPanel;
    private ScenesManager scenesManagerScript;
    private Scene scene;
    private int maxScenes;
    private int currentSceneNumber;
    private int test;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        maxScenes = SceneManager.sceneCountInBuildSettings; // Count the number of scenes in the build project
    }

    void Start() {
    }

    void Update() { 
        GoToNextScene();
    }

    void GoToNextScene() {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        scene = SceneManager.GetActiveScene(); //TODO: only the main scene is active scene as the other are as additive;
        currentSceneNumber = scene.buildIndex; // Check which scene number is active

        if(wristPanel.tag == "Next") {
            Debug.Log(currentSceneNumber);

            if(currentSceneNumber < maxScenes - 1) {
                scenesManagerScript.SwitchScene(currentSceneNumber + 1);
                currentSceneNumber++;
            } else {
                SceneManager.LoadScene(2, parameters);
                SceneManager.UnloadSceneAsync(maxScenes - 1);
                currentSceneNumber = 2;
            }

            wristPanel.tag = "Untagged";
        }
    }
    
}
