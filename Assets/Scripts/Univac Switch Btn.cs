using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnivacSwitchBtn : MonoBehaviour
{

    internal Animator switchBtnAnimator;
    [SerializeField] private GameObject univacManager;

    void Awake() {
        switchBtnAnimator = transform.gameObject.GetComponent<Animator>();
    }

    void Start() {
        
    }

    void Update() {
        
    }

    public void OnTriggerEnter() {
        Debug.Log("switch");
        switchBtnAnimator.SetBool("isOn", !switchBtnAnimator.GetBool("isOn"));
        univacManager.GetComponent<UnivacManager>().RunUnivac();
    }

    // OK Si trigger sur btn collider, btn animator -> setBool IsOn en true

    // Si IsOn en true, afficher code sur l'imprimante, afficher trigger pour le poignet

    //Si on trigger avec le poignet, afficher code sur le poignet. (wrist manager)
}
