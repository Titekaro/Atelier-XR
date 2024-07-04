using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacintoshManager : MonoBehaviour
{
    private Player playerScript;

    [SerializeField] private GameObject playerPositionResetter;
    [SerializeField] private GameObject Mouse;
    [SerializeField] private GameObject Diskette;
    [SerializeField] private GameObject Sol;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Start() {
        
    }

    void Update() {
    }

    void RunUnivac() {
        }
    
}
