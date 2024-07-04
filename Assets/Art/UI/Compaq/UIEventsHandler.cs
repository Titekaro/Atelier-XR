using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEventsHandler : MonoBehaviour
{
    [SerializeField]
   private UIDocument uiDoc;

    // Start is called before the first frame update
    void OnEnable()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;


        VisualElement rootElement = uiDoc.rootVisualElement;
        Button btn = rootElement.Q<Button>("test_btn_1");
        // Listen for clicks on btn
        btn.RegisterCallback<ClickEvent>(HandleClick);
        btn.RegisterCallback<PointerEnterEvent>(HandleMouseHover);

    }

    public void HandleClick(ClickEvent evt){
        Debug.Log("Clicked");
    }
    private void HandleMouseHover(PointerEnterEvent evt)
    {
        Debug.Log("Hovered");
    }
        
    
}
