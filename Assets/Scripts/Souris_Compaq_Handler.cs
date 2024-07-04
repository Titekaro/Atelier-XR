using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class Souris_Compaq_Handler : MonoBehaviour
{
    [SerializeField] private bool click;
    public UnityEvent OnClick;


    // Start is called before the first frame update
    void Start()
    {
     click = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(click == true){
            OnClick.Invoke();


        }
    }
}
