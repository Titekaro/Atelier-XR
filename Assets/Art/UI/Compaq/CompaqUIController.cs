//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;
using System.Collections;

public class CompaqUIController : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootElement;
    private bool Connected = false;
    private Button Internet_Explorer;
    private Button Internet_Connexion;
    private Button commentaires;
    private VisualElement window1;
    private VisualElement window2;
    private VisualElement app;
    private VisualElement pointer;
    private float soundLength = 28f;

    public UnityEvent OnCodeFound;
    private AudioSource audioSource;
    public AudioClip soundClip;



    void OnEnable()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;

        rootElement = uiDoc.rootVisualElement;

        // UI ELEMENTS
        // Mouse
        pointer = rootElement.Q<VisualElement>("pointer");
        // Windows
        window1 = rootElement.Q<VisualElement>("window1");
        window2 = rootElement.Q<VisualElement>("window2");
        app = rootElement.Q<VisualElement>("app");



        // Icons
        Internet_Explorer = rootElement.Q<Button>("Internet_Explorer");
        Internet_Connexion = rootElement.Q<Button>("Internet_Connexion");
        commentaires = rootElement.Q<Button>("commentaires");
        // HIDING WINDOWS
        // closing all windows
        window1.AddToClassList("closed");
        window2.AddToClassList("closed");
        app.AddToClassList("closed");

        audioSource = GetComponent<AudioSource>();

        // INTERACTION
        // Listening for events
        Internet_Connexion.RegisterCallback<ClickEvent>(HandleConnexionClick);
        Internet_Connexion.RegisterCallback<PointerEnterEvent>(HandleMouseHover);

        Internet_Explorer.RegisterCallback<PointerEnterEvent>(HandleMouseHover);
        Internet_Explorer.RegisterCallback<ClickEvent>(HandleExplorerClick);

        commentaires.RegisterCallback<ClickEvent>(HandleCommClick);
        commentaires.RegisterCallback<PointerEnterEvent>(HandleMouseHover);




    }

    public void  SetCursorPosition(Vector2 position)
    {
        // change pointer top and left values to match mouse position
        pointer.style.top = new StyleLength(position.y);
        pointer.style.left = new StyleLength(position.x);
    }


    private void HandleConnexionClick(ClickEvent evt)
    {
        StartCoroutine(Connexion());
    }
     private IEnumerator Connexion()
    {
       audioSource.Play();
        app.RemoveFromClassList("closed");
        yield return new WaitForSeconds(soundLength);
        app.AddToClassList("closed");
        Connected = true;



    }
     private void HandleCommClick(ClickEvent evt)
    {
        Debug.Log("Clicked");
        window2.RemoveFromClassList("closed");
        OnCodeFound.Invoke();


    }

    private void HandleExplorerClick(ClickEvent evt)
    {
        if(Connected == true){
        Debug.Log("Clicked");
        window1.RemoveFromClassList("closed");}

    }



    private void HandleMouseHover(PointerEnterEvent evt)
    {
        Debug.Log("Hovered");
    }
}
