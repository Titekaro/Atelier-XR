using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class HandScan : MonoBehaviour
{
    private ScenesManager scenesManagerScript;
    private XRDirectInteractor hand;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        hand = GameObject.Find("Left Controller").GetComponent<XRDirectInteractor>();
    }

    void Start() {  
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other){
        //Ajouter detection uniquement quand c'est les mains
        Debug.Log("collision " + other.tag);

        if(other.tag == "Hand") {
            XRBaseController leftHandController = GameObject.Find("Left Controller").GetComponent<XRBaseController>();
            if (leftHandController != null) leftHandController.SendHapticImpulse(0.5f, 0.5f);
            
            StartCoroutine(DelayAction(5));
        }
    }

    void OnTriggerExit() {
        hand.playHapticsOnHoverEntered = false;
    }
    
    IEnumerator DelayAction(float delayTime) {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        scenesManagerScript.SwitchScene(3);
    }
}
