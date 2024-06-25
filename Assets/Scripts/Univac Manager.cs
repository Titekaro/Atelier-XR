using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnivacManager : MonoBehaviour
{
    private Player playerScript;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        playerScript.ResetPlayerPosition(new Vector3(-7.97f,0f,3.82f));
    }

    void Start() {
        
    }

    void Update() {
        
    }
}
