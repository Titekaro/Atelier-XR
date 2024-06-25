using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject player;

    void Awake() {
        player = GameObject.Find("XR Rig");
    }
    void Start() { 
    }

    void Update() { 
    }

    public void ResetPlayerPosition(Vector3 newPosition) {
        player.transform.position = newPosition;
        Debug.Log("player position reset: " + player.transform.position);
    }
}
