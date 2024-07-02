using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIInfo : MonoBehaviour
{

    [SerializeField] private GameObject infoPanel;

    void Awake() {
        infoPanel.SetActive(false);
    }

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
