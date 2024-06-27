using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    private Player playerScript;

    [SerializeField] private GameObject playerPositionResetter;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
    }

    void Start() {
        playerScript.ResetPlayerPosition(playerPositionResetter);
    }

    void Update() {
    }

}
