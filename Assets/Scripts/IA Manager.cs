using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    private Player playerScript;

    [SerializeField] private GameObject playerPositionResetter;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Start() {
    }

    void Update() {
    }

}
