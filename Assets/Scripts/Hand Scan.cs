using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandScan : MonoBehaviour
{
    private ScenesManager scenesManagerScript;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
    }

    void Start() {  
    }

    void Update() {
    }

    void OnTriggerEnter() {
        scenesManagerScript.SwitchScene(3);
    }

}
