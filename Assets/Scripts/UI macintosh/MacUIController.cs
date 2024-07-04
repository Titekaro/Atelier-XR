//using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class MacUIController : MonoBehaviour
{
    public UIDocument uiDoc;
    private VisualElement rootElement;
    private Button disketteBtn;
    private Button folderBtn1;
    private Button folderBtn2;
    private Button appBtn1;
    private VisualElement window1;
    private VisualElement window2;
    private VisualElement window3;
    private VisualElement app;
    private VisualElement pointer;

    public UnityEvent OnCodeFound;

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
        window3 = rootElement.Q<VisualElement>("window3");
        app = rootElement.Q<VisualElement>("app");

        // Icons
        disketteBtn = rootElement.Q<Button>("diskette");
        folderBtn1 = rootElement.Q<Button>("folder");
        folderBtn2 = rootElement.Q<Button>("folder2");
        appBtn1 = rootElement.Q<Button>("appicon");

        // HIDING WINDOWS
        // closing all windows
        window1.AddToClassList("closed");
        window2.AddToClassList("closed");
        window3.AddToClassList("closed");
        app.AddToClassList("closed");

        // INTERACTION
        // Listening for events
        disketteBtn.RegisterCallback<ClickEvent>(HandleDisketteClick);
        disketteBtn.RegisterCallback<PointerEnterEvent>(HandleMouseHover);
        folderBtn1.RegisterCallback<ClickEvent>(HandleFolderClick);
        folderBtn2.RegisterCallback<ClickEvent>(HandleFolder2Click);
        appBtn1.RegisterCallback<ClickEvent>(HandleApp1Click);



    }

    public void  SetCursorPosition(Vector2 position)
    {
        // change pointer top and left values to match mouse position
        pointer.style.top = new StyleLength(position.y);
        pointer.style.left = new StyleLength(position.x);
    }


    private void HandleDisketteClick(ClickEvent evt)
    {
        Debug.Log("Clicked");
        window1.RemoveFromClassList("closed");

    }

    private void HandleFolderClick(ClickEvent evt)
    {
        Debug.Log("Clicked");
        window2.RemoveFromClassList("closed");

    }
    private void HandleFolder2Click(ClickEvent evt)
    {
        Debug.Log("Clicked");
        window3.RemoveFromClassList("closed");

    }
    private void HandleApp1Click(ClickEvent evt)
    {
        Debug.Log("Clicked");
        app.RemoveFromClassList("closed");

        OnCodeFound.Invoke();
    }

    private void HandleMouseHover(PointerEnterEvent evt)
    {
        Debug.Log("Hovered");
    }
}
