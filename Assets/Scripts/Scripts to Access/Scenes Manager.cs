using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour 
{
    private Init InitScript;

    void Awake() {
        InitScript = GameObject.Find("Scripts Access").GetComponent<Init>(); // Access the wanted script in "Scripts Access"
    }

    void Start() {
    }

    void Update() {
    }

    // Call the number of the scene to load in addition of the main scene
    public void SwitchScene(int sceneNumber) {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);
        int numberOfScenesLoaded = SceneManager.sceneCount;
        List<string> loadedScenes = new List<string>(); // Create an empty list

        for(int i = 0; i < numberOfScenesLoaded; i++) {
            Debug.Log(SceneManager.GetSceneAt(i).name);
            loadedScenes.Add(SceneManager.GetSceneAt(i).name); // Put the name of all the loaded scenes, before switch scene, in the list
        }

        // On passe le nom de la scène actuelle dans une variable, avant de charger la nouvelle scène, puis une fois la nouvelle scène chargée, on retire la scène contenue dans cette variable
        InitScript.previousSceneLoaded = loadedScenes.Last();
        
        SceneManager.LoadScene(sceneNumber, parameters);
        SceneManager.UnloadSceneAsync(InitScript.previousSceneLoaded); // sceneNumber - 1

        Debug.Log("scene loaded");

    }

    public void QuitGame() {
        Application.Quit();
    }
}
