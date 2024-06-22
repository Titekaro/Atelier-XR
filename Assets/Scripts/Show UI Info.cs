using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIInfo : MonoBehaviour
{

    [SerializeField] private GameObject panelInfo;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter() {
        panelInfo.SetActive(true);
    }

    void OnTriggerExit() {
        panelInfo.SetActive(false);
    }

}
