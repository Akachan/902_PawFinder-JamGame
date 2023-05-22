using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class UIInputsMI : MonoBehaviour, InputControl.IUIActions
{
    MIEvents mIEvents;
    
    InputControl uiControls;
    Vector2 direction = new Vector2();
  
    private void Awake() {
        mIEvents = GetComponent<MIEvents>();
    }
     private void Start()
    {
        uiControls = new InputControl();
        uiControls.UI.SetCallbacks(this);
        uiControls.UI.Enable();
    }


    //para teclado y joystick
    public void OnAction(InputAction.CallbackContext context)
    {
        if(context.performed )
        {
            mIEvents.InvokeOnSelect();
        }
    }

    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            mIEvents.EscapeMenu();
        }
    }

    public void OnNavigate(InputAction.CallbackContext context)
    {
        
        direction = context.ReadValue<Vector2>();

    }

    public float GetXNavigation()
    {
        return direction.x;
    }



    



//*************************************************************


    public void OnSubmit(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        //throw new NotImplementedException();
    }


}