using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectcode : MonoBehaviour
{
    private UnivacManager univacManagerScript;
    private bool canTrigger;

    void Awake() {
    }

    void Start() { 
        canTrigger = true; // Bool to allow only one trigger on the zone to collect code
    }

    void Update() {   
    }

    
    private void OnTriggerEnter(Collider other) {
        if(canTrigger == true) {
            univacManagerScript = GameObject.Find("Univac Manager").GetComponent<UnivacManager>();
            // Add script for Macintosh
            // Add script for Compaq

            switch(other.tag) {
                case "Code Univac":
                    univacManagerScript.OnCodeFound();
                    break;
                case "Code Macintosh":
                    // Call Macintosh fnct OnCodeFound();
                    break;
                case "Code Compaq":
                    // Call Compaq fnct OnCodeFound();
                    break;
            }
        }
    }

    private void OnTriggerExit() {
        canTrigger = false;
    }
}
