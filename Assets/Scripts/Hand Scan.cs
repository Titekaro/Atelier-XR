using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScan : MonoBehaviour
{
    private ScenesManager scenesManager;

    void Awake() {
    }

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter() {
        new WaitForSeconds(5);
        //scenesManager.SwitchScene(2);
    }
}
