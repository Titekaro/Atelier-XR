using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerWristManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button codeBtn;
    [SerializeField] private Button debugBtn;
    [SerializeField] private GameObject debugContent;
    [SerializeField] private GameObject codeContent;

    private ScenesManager scenesManagerScript;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
    }

    void Start() {
        codeBtn.onClick.AddListener(ToggleMenuPanelCode);
        debugBtn.onClick.AddListener(ToggleMenuPanelDebug);
    }

    void Update() {
    }

    void ToggleMenuPanelCode() {

        Debug.Log("Code content " + codeContent.activeSelf);

        if(codeContent.activeSelf == true) { //si le code panel est ouvert, fermer code panel
            codeContent.SetActive(false);
        } else { //si le code panel est fermé, ouvrir le code panel

            if(debugContent.activeSelf == true) { //si le debug panel est ouvert, switch content
                debugContent.SetActive(false);
            }

            codeContent.SetActive(true);
        }

    }

    void ToggleMenuPanelDebug() {
        
        Debug.Log("Debug content " + debugContent.activeSelf);

        if(debugContent.activeSelf == true) { //si le debug panel est ouvert, fermer debug panel
            debugContent.SetActive(false);
        } else { //si le debug panel est fermé, ouvrir le debug panel 

            if(codeContent.activeSelf == true) { //si le code panel est ouvert, switch content
                codeContent.SetActive(false);
            }

            debugContent.SetActive(true);
        }

    }
    
}
