using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerWristManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button codeBtn;
    [SerializeField] private Button debugBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private GameObject debugContent;
    [SerializeField] private GameObject codeContent;

    [SerializeField] private TextMeshProUGUI codeUnivac;
    [SerializeField] private TextMeshProUGUI codeMacintosh;
    [SerializeField] private TextMeshProUGUI codeCompaq;

    private TextMeshProUGUI codeContentTitle;
    private GameObject code;
    internal int totalCodeToFind;
    internal int totalCodeFound = 0;

    void Awake() {
        codeContentTitle = codeContent.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        code = codeContent.transform.Find("Code").GetComponent<GameObject>();
        
        totalCodeToFind = SceneManager.sceneCountInBuildSettings - 3;
    }

    void Start() {
        codeBtn.onClick.AddListener(TogglePanelCode);
        debugBtn.onClick.AddListener(TogglePanelDebug);
    }

    void Update() {
        codeContentTitle.text = totalCodeFound.ToString() + "/" + totalCodeToFind.ToString() + " fragments de code trouvés";
    }

    void TogglePanelCode() {
        if(codeContent.activeSelf == true) { //si le code panel est ouvert, fermer code panel
            codeContent.SetActive(false);
        } else { //si le code panel est fermé, ouvrir le code panel

            if(debugContent.activeSelf == true) { //si le debug panel est ouvert, switch content
                debugContent.SetActive(false);
            }

            codeContent.SetActive(true);
        }
    }

    void TogglePanelDebug() {
        if(debugContent.activeSelf == true) { //si le debug panel est ouvert, fermer debug panel
            debugContent.SetActive(false);
        } else { //si le debug panel est fermé, ouvrir le debug panel 

            if(codeContent.activeSelf == true) { //si le code panel est ouvert, switch content
                codeContent.SetActive(false);
            }

            debugContent.SetActive(true);
        }
    }

    /* TODO
        Serait mieux d'ajouter automatiquement en code les text gameobjects en fonction 
        du nombre de scènes qu'on a et y lier le tag de la scène.
        List ou array et générer une place aléatoire pour les text des codes initiaux/ 
        couches non abîmées (qu'on ne doit pas trouver)
    */
    public void CollectCode(string sceneName) {
        totalCodeFound ++; // Increment the number of code found each time a code is found

        // Open code panel to access code text
        if(debugContent.activeSelf == true) {
            debugContent.SetActive(false);
        }
        codeContent.SetActive(true);

        // Add the code found on the wrist
        switch (sceneName) {
            case "Univac":
                codeUnivac.text = "5B3";
                break;
            case "Macintosh":
                codeMacintosh.text = "221";
                break;
            case "Compaq":
                codeCompaq.text = "FF7";
                break;
        }

        /*
        // Get all text children in GameObject code
        foreach(Transform child in code.GetComponentsInChildren<Transform>()) {
            Debug.Log(child);

            if(child.tag == "Code " + sceneName) {
                Debug.Log(child.tag);

                // Add the code found on the wrist
                switch (child.tag) {
                    case "Code Univac":
                        child.GetComponent<TextMeshProUGUI>().text = "5B3";
                        break;
                    case "Code Macintosh":
                        //code.FindChildWithTag("Code Macintosh").GetComponent<TextMeshProUGUI>().text = "221";
                        break;
                    case "Code Compaq":
                        //code.FindChildWithTag("Code Macintosh").GetComponent<TextMeshProUGUI>().text = "FF7";
                        break;
                }
            }
        }
        */
    } 
}
