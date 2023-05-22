using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputCelu : MonoBehaviour, Control.IPlayerActions
{
    CellphoneMover cellphoneMover;
    AppController appController;
    Control gameControls;
    AppShooter appShooter;

    private void Awake() 
    {
        cellphoneMover = FindObjectOfType<CellphoneMover>();
        appController = FindObjectOfType<AppController>();
        appShooter = FindObjectOfType<AppShooter>();
    }

    private void Start()
    {
        gameControls = new Control();
        gameControls.Player.SetCallbacks(this);
        gameControls.Player.Enable();
    }


    
    public void OnUseCelu(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("aprestaste la g");
            cellphoneMover.initialMove();
        }
    }

    public void OnUseApp(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            appController.PawFinderOnOff();
        }
    }
    public void OnShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            appShooter.PerformRaycast();
        }
    }




    //***********************************************************
    public void OnJump(InputAction.CallbackContext context) {}
    public void OnLook(InputAction.CallbackContext context) {}
    public void OnMove(InputAction.CallbackContext context) {}
    public void OnSprint(InputAction.CallbackContext context) {}


}
