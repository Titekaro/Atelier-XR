using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnivacManager : MonoBehaviour
{
    private Player playerScript;

    [SerializeField] private GameObject bobine;
    [SerializeField] private GameObject perforedCards;
    [SerializeField] private GameObject pressCards;
    [SerializeField] private GameObject buttonOn;

    void Awake() {
        playerScript = GameObject.Find("Scripts Access").GetComponent<Player>();
        playerScript.ResetPlayerPosition(new Vector3(-7.97f,0f,3.82f));
    }

    void Start() {
        
    }

    void Update() {
        RunUnivac();
    }

    void RunUnivac() {
        if(bobine.tag == "Set" && perforedCards.tag == "Set" && pressCards.tag == "Set") {
            buttonOn.SetActive(true);
        } else {
            buttonOn.SetActive(false);
        }
    }
}
