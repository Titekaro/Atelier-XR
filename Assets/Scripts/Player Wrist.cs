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
    [SerializeField] private GameObject debugContent;
    [SerializeField] private GameObject codeContent;

    private ScenesManager scenesManagerScript;
    private TextMeshProUGUI codeContentTitle;
    private GameObject code;
    internal int totalCodeToFind;
    internal int totalCodeFound = 0;

    void Awake() {
        scenesManagerScript = GameObject.Find("Scripts Access").GetComponent<ScenesManager>(); // Access the wanted script in "Scripts Access"
        codeContentTitle = codeContent.transform.Find("Title").GetComponent<TextMeshProUGUI>();
        code = codeContent.transform.Find("Code").GetComponent<GameObject>();
        
        totalCodeToFind = SceneManager.sceneCountInBuildSettings - 3;
        codeContentTitle.text = totalCodeFound.ToString() + "/" + totalCodeToFind.ToString() + " fragments de code trouvés";
    }

    void Start() {
        codeBtn.onClick.AddListener(TogglePanelCode);
        debugBtn.onClick.AddListener(TogglePanelDebug);
    }

    void Update() {
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

    public void CollectCode(string sceneName) {
        totalCodeFound ++; // Increment the number of code found each time a code is found

        // Add the code found on the wrist
        switch (sceneName) {
            case "Univac":
                code.FindChildWithTag("Code Univac").GetComponent<TextMeshProUGUI>.text = "5B3";
                break;
            case "Macintosh":
                code.FindChildWithTag("Code Macintosh").GetComponent<TextMeshProUGUI>.text = "221";
                break;
            case "Compaq":
                code.FindChildWithTag("Code Macintosh").GetComponent<TextMeshProUGUI>.text = "FF7";
                break;
        }
    }
    
}
