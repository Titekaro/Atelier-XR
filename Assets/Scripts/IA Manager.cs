using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAManager : MonoBehaviour
{
    private Player playerScript;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        playerScript.ResetPlayerPosition(new Vector3(-2.7f,0f,-1.2f));
    }

    void Start() {
    }

    void Update() {
    }

}
