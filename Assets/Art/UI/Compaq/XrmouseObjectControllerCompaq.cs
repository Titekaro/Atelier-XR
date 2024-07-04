using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class XrmouseObjectControllerCompaq : MonoBehaviour
{
    [SerializeField] GameObject mouseObject;
    [SerializeField] GameObject screenObject;
    [SerializeField] CompaqUIController UI;
    [SerializeField] float mouseSpeed = 0.1f;
    [SerializeField] float screenSizeX = 256f;
    [SerializeField] float screenSizeY = 256f;

    [SerializeField] bool useVirtualPointer = false;
    [SerializeField] bool debugMode = false;
    private Vector3 previousMousePosition;
    private Vector2 mouseDirection;
    private Vector3 cursorPosition;
    private Vector2 cursorScreenPosition;

    private Vector3 screenObjectSize;
    private Vector3 screenObjectPosition;
    private Vector3 screenObjectRotation;

    private VisualElement previousTargetElement;

    // Helper
    [SerializeField] private float rayLength = 2f; //rayLength
    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Awake(){
        this.AddComponent<LineRenderer>();
        lineRenderer = GetComponent<LineRenderer>();
        // set the linerenderer aspect to a small green line
        lineRenderer.startColor = Color.blue;
        lineRenderer.endColor = Color.cyan;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;

        cursorScreenPosition = new Vector2(0, 0);

    }
    void Start()
    {
        // get screenObject size
        screenObjectSize = screenObject.GetComponent<Renderer>().bounds.size;
        // get screenObject position
        screenObjectPosition = screenObject.transform.position;
        // get screenObject rotation
        screenObjectRotation = screenObject.transform.rotation.eulerAngles;
        //Rotate this object to match scrrenObject rotation
        //transform.rotation = Quaternion.Euler(screenObjectRotation);
        //Position this object at the center of the screenObject
        cursorPosition = transform.position = screenObjectPosition;
        //offset the position to be a little bit in front of the screenObject
        //transform.position += transform.forward * -1f;
        transform.localPosition += transform.forward * -1f;

        //set mouse direction to 0
        mouseDirection = Vector2.zero;


    }

    // Update is called once per frame
    void Update()
    {
        if(mouseObject == null) {
            Debug.LogWarning("Missing Mouse Object !");
            return;
        }
        
        GetMouseObjectMousement();
        SetScreenPointerPosition();
        CastMouseRay();
        PointerSync();

        
        //debug tools
        MoveCheck();
        ClickCheck();
    }

    private void PointerSync(){
        if(!useVirtualPointer) return;
        UI.SetCursorPosition(cursorScreenPosition);

    }

    private void MoveCheck(){
        Vector3 fakepos = new Vector3(0,0,0);

        if(fakepos != Vector3.zero){
            cursorPosition += fakepos;
            transform.position = cursorPosition;
        }
    }

    private void ClickCheck(){
        if (Input.GetKeyDown(KeyCode.C)){Click();}
    }
    private void CastMouseRay()
    {
        Ray ray = new Ray(transform.position, -1 * transform.up);
        if (lineRenderer != null && debugMode)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position - transform.up * rayLength);
        }

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider != null && hit.collider.GetComponent<UIDocument>() != null)
            {
                // get the UI Toolkit element that is hovered in the UI document
                UIDocument uiDocument = hit.collider.GetComponent<UIDocument>();
                if (uiDocument != null)
                {
                    VisualElement targetElement = uiDocument.rootVisualElement.panel.Pick(cursorScreenPosition);
                    if(targetElement == previousTargetElement) return;


                    if(previousTargetElement != null) {
                        PointerLeaveEvent pointerLeaveEvent = PointerLeaveEvent.GetPooled(new PointerLeaveEvent());
                        pointerLeaveEvent.target = previousTargetElement;
                        //Debug.Log("send pointer leave event");
                        previousTargetElement.SendEvent(pointerLeaveEvent);         
                    }

                    // Send a pointer over event
                    PointerEnterEvent pointerEnterEvent = PointerEnterEvent.GetPooled(new PointerEnterEvent());
                    pointerEnterEvent.target = targetElement;
                    //Debug.Log("send pointer enter event");
                    targetElement.SendEvent(pointerEnterEvent);                 

                    previousTargetElement = targetElement;
                    //Debug.Log(previousTargetElement.name);

                }
            }
        };
    }

    // Get mouse object position
    private void GetMouseObjectMousement(){

        Vector3 mouseObjectPosition = mouseObject.transform.position;
        //generate delta between previous mouse position and current mouse position. Return movement vector (0 no movement 1 or -1 mouvement)
        Vector3 mouseDelta = mouseObjectPosition - previousMousePosition;

        switch (Mathf.Clamp(mouseDelta.x, -1, 1)) {
            case < 0: // left
                mouseDirection.x = -1;
                break;
            case > 0: // right
                mouseDirection.x = 1;
                break;
            default:
                mouseDirection.x = 0;
                break;
        }

        switch (Mathf.Clamp(mouseDelta.z, -1, 1)) {
            case < 0: // up
                mouseDirection.y = -1;
                break;
            case > 0: // down
                mouseDirection.y = 1;
                break;
            default:
                mouseDirection.y = 0;
                break;
        }
        

        previousMousePosition = mouseObjectPosition;
    }

    private void SetScreenPointerPosition(){
        if(mouseDirection.x == 0 && mouseDirection.y == 0) return; // no movement        

        //move this oject in the direction of the mouse and clamp it to the screenObject
        float screenXmin = screenObject.transform.position.x - screenObjectSize.x / 2;
        float screenXmax = screenObject.transform.position.x + screenObjectSize.x / 2;
        float screenZmin = screenObject.transform.position.y - screenObjectSize.y / 2;
        float screenZmax = screenObject.transform.position.y + screenObjectSize.y / 2;

        if(mouseDirection.x < 0 && cursorPosition.x > screenXmin){cursorPosition.x -= mouseSpeed;}
        if(mouseDirection.x > 0 && cursorPosition.x < screenXmax){cursorPosition.x += mouseSpeed;}
        if(mouseDirection.y < 0 && cursorPosition.y > screenZmin){cursorPosition.y -= mouseSpeed;}
        if(mouseDirection.y > 0 && cursorPosition.y < screenZmax){cursorPosition.y += mouseSpeed;}
        
        cursorPosition.z = screenObject.transform.position.z - 1f;
        this.transform.position = cursorPosition;

        cursorScreenPosition.x = Mathf.RoundToInt(Math.Clamp((cursorPosition.x + screenObjectSize.x/2) / screenObjectSize.x * screenSizeX, 0f, screenSizeX));
        cursorScreenPosition.y = Mathf.RoundToInt(Math.Clamp(Math.Abs(cursorPosition.y - screenObjectSize.y) / screenObjectSize.y * screenSizeY, 0f, screenSizeY));

        //Debug.Log(cursorScreenPosition);
    }

    public void Click() {
        if (previousTargetElement != null){
            ClickEvent clickEvent = ClickEvent.GetPooled(new ClickEvent());
            clickEvent.target = previousTargetElement;
            Debug.Log("send click event");
            previousTargetElement.SendEvent(clickEvent);
        }
    }
}