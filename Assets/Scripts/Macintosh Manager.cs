using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MacintoshManager : MonoBehaviour
{
    private Player playerScript;
    private ScenesManager scenesManagerScript;
    private PlayerWristManager wristManagerScript;
    private GameObject leftHand;

    [SerializeField] private GameObject playerPositionResetter;
    [SerializeField] private GameObject Mouse;
    [SerializeField] private GameObject Diskette;
    [SerializeField] private GameObject Sol;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();

        leftHand = GameObject.Find("Left Controller");
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Update() {
    }

    // Method called when the wrist zone is triggered with the player wrist
    public void OnCodeFound() {
        wristManagerScript = GameObject.Find("Wrist").GetComponent<PlayerWristManager>();
        wristManagerScript.CollectCode("Macintosh");
        
        // Add haptic impulse
        XRBaseController leftHandController = leftHand.GetComponent<XRBaseController>();

        if(leftHandController != null) {
            leftHandController.SendHapticImpulse(0.5f, 0.5f);
        }

        // Call switch scene method with delay
        StartCoroutine(DelayAction(1));
    }

    IEnumerator DelayAction(float delayTime) {
        //Wait for the specified delay time before continuing.
        yield return new WaitForSeconds(delayTime);
        scenesManagerScript.SwitchScene(5);
    }
    
}
