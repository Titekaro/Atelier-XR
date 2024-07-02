using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UnivacManager : MonoBehaviour
{
    private ScenesManager scenesManagerScript;
    private Player playerScript;
    private UnivacSwitchBtn switchBtnScript; // Script to access the switchBtnAnimator
    private PlayerWristManager wristManagerScript;
    private GameObject leftHand;

    [SerializeField] private GameObject playerPositionResetter;
    [SerializeField] private GameObject bobine;
    [SerializeField] private GameObject perforedCards;
    [SerializeField] private GameObject pressCards;
    [SerializeField] private GameObject wristTrigger;
    [SerializeField] private GameObject code;
    [SerializeField] private GameObject errorMessage;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();

        leftHand = GameObject.Find("Left Controller");

        errorMessage.SetActive(false);
        wristTrigger.SetActive(false);
        code.SetActive(false);
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Update() {
        RunUnivac();
    }

    // Method called when we switch the button
    public void RunUnivac() {
        switchBtnScript = GameObject.Find("Trieuse_switchBtn").GetComponent<UnivacSwitchBtn>();

        if(switchBtnScript.switchBtnAnimator.GetBool("isOn") == true) {
            if(bobine.tag == "Set" && perforedCards.tag == "Set" && pressCards.tag == "Set") {
                errorMessage.SetActive(false);
                code.SetActive(true);
                wristTrigger.SetActive(true);
            } else {
                errorMessage.SetActive(true);
                code.SetActive(false);
                wristTrigger.SetActive(false);
            }
        } else {
            errorMessage.SetActive(false);
            code.SetActive(false);
            wristTrigger.SetActive(false);
        }
    }

    // Method called when the wrist zone is triggered with the player wrist
    public void OnCodeFound() {
        wristManagerScript = GameObject.Find("Wrist").GetComponent<PlayerWristManager>();
        wristManagerScript.CollectCode("Univac");
        
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
        scenesManagerScript.SwitchScene(4);
    }

}
