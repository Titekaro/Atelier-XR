using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    private Player playerScript;
    private PlayerWristManager wristManagerScript;

    [SerializeField] private GameObject playerPositionResetter;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        wristManagerScript = GameObject.Find("Wrist").GetComponent<PlayerWristManager>();
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);

        if (wristManagerScript.totalCodeFound == wristManagerScript.totalCodeToFind) {
            // Show wrist trigger
        }
    }

    void Update() {
    }

}
