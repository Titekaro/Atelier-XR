using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnivacManager : MonoBehaviour
{
    private Player playerScript;
    private UnivacSwitchBtn switchBtnScript; // Script to access the switchBtnAnimator
    private PlayerWristManager wristManagerScript;

    [SerializeField] private GameObject playerPositionResetter;
    [SerializeField] private GameObject bobine;
    [SerializeField] private GameObject perforedCards;
    [SerializeField] private GameObject pressCards;
    [SerializeField] private GameObject wristTrigger;
    [SerializeField] private GameObject code;
    [SerializeField] private GameObject errorMessage;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        wristManagerScript = GameObject.Find("Wrist").GetComponent<PlayerWristManager>();
        switchBtnScript = GameObject.Find("Trieuse_switchBtn").GetComponent<UnivacSwitchBtn>();

        errorMessage.SetActive(false);
        wristTrigger.SetActive(false);
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Update() {
    }

    public void RunUnivac() {

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
        }
    }

    public void OnCodeFound() {
        wristManagerScript.CollectCode("Univac");

        // Add haptic impulse
        // Add switch scene
    }

}
