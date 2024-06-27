using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class HandScan : MonoBehaviour
{
    private ScenesManager scenesManagerScript;
    private GameObject leftHand;
    private GameObject rightHand;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        leftHand = GameObject.Find("Left Controller");
        rightHand = GameObject.Find("Right Controller");
    }

    void Start() {  
    }

    void Update() {
    }

    void OnTriggerEnter(Collider other){
        //Ajouter detection uniquement quand c'est les mains
        Debug.Log("collision " + other.tag);

        XRBaseController rightHandController = rightHand.GetComponent<XRBaseController>();
        XRBaseController leftHandController = leftHand.GetComponent<XRBaseController>();

        switch(other.tag) {
            case "HandRight":
                if(rightHandController != null) {
                    rightHandController.SendHapticImpulse(0.5f, 2f);
                }
                StartCoroutine(DelayAction(2));
            break;
            case "HandLeft":
                if(leftHandController != null) {
                    leftHandController.SendHapticImpulse(0.5f, 2f);
                }
                StartCoroutine(DelayAction(2));
            break;
        }

    }
    
    IEnumerator DelayAction(float delayTime) {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        scenesManagerScript.SwitchScene(3);
    }
}
