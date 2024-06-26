using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using Unity.XR.CoreUtils;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerHead;

    void Awake() {
    }

    void Start() { 
    }

    void Update() { 
    }

    public void ResetPlayerPosition(GameObject resetter) {
        //Get the rotation angle value to apply at the reset by calculating the angle difference between the two elements
        float rotationY = resetter.transform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        //Apply the rotation
        player.transform.Rotate(0, rotationY, 0);

        //Get the position difference by the same way
        // /!!\ le Y de la camera !
        Vector3 newPosition = new Vector3(resetter.transform.position.x - playerHead.transform.position.x, 0.1f, resetter.transform.position.z - playerHead.transform.position.z);
        //Add the position difference to the position of the player
        player.transform.position += newPosition;

        //Debug.Log("player position reset: " + newPosition);
        Debug.Log(resetter.transform.position + " " + playerHead.transform.position + " " + newPosition);
    }
}
