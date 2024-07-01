using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnivacManager : MonoBehaviour
{
    private Player playerScript;
    private UnivacSwitchBtn switchBtnScript; // Script to access the switchBtnAnimator

    [SerializeField] private GameObject playerPositionResetter;
    [SerializeField] private GameObject bobine;
    [SerializeField] private GameObject perforedCards;
    [SerializeField] private GameObject pressCards;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        switchBtnScript = GameObject.Find("Trieuse_switchBtn").GetComponent<UnivacSwitchBtn>();
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Update() {
    }

    public void RunUnivac() {

        if(switchBtnScript.switchBtnAnimator.GetBool("isOn") == true) {
            if(bobine.tag == "Set" && perforedCards.tag == "Set" && pressCards.tag == "Set") {
                Debug.Log("can get code");
            } else {
                Debug.Log("can NOT get code");
                Debug.Log("Vous devz placer les elements pour que ça fonctionne");
            }
        }
    }

}
