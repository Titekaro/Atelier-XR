using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIInfo : MonoBehaviour
{

    [SerializeField] private GameObject infoPanel;

    void Start() {
        
    }

    void Update() {
        
    }

    void OnTriggerEnter() {
        infoPanel.SetActive(true);
    }

    void OnTriggerExit() {
        infoPanel.SetActive(false);
    }

}
