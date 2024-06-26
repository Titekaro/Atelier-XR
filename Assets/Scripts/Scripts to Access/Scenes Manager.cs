using System.Collections;
using System.Collections.Generic;
using GLTFast.Schema;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    private GameObject fadeScreen;
    private CanvasGroup fade;

    void Awake() {
        fadeScreen = GameObject.Find("Fade");
        fade = fadeScreen.GetComponent<CanvasGroup>();
        fadeScreen.SetActive(false);
    }

    void Start() {
    }

    void Update() {
    }

    // Call the number of the scene to load in addition of the main scene
    public void SwitchScene(int sceneNumber) {
        var parameters = new LoadSceneParameters(LoadSceneMode.Additive);

        FadeScreen();
        
        SceneManager.LoadScene(sceneNumber, parameters);
        SceneManager.UnloadSceneAsync(sceneNumber - 1);

        Debug.Log("scene loaded");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void FadeScreen() {
        //set canvas to active true
        fadeScreen.SetActive(true);

        if(fade.alpha < 1) {
            fade.alpha += Time.deltaTime;
        }

        //doit disparaitre noir
        //set canvas to active false
        if(fade.alpha >= 0) {
            fade.alpha -= Time.deltaTime;

            if(fade.alpha == 0) {
                fadeScreen.SetActive(false);
            }
        }

    }
}
