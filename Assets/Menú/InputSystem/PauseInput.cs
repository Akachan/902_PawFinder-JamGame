using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseInput : MonoBehaviour, Control.IPauseActions
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] InputCelu playerInput;
    [SerializeField] UIInputsMP uIInput;
    [SerializeField] FirstPersonController fps;
    [SerializeField] Timer timer;
    Control control;

    bool isInPauseMenu = false;
    

    private void Start()
    {
        control = new Control();
        control.Pause.SetCallbacks(this);
        control.Pause.Enable();

        playerInput.gameObject.SetActive(!isInPauseMenu);
        uIInput.gameObject.SetActive(isInPauseMenu);

        menuPausa.SetActive(isInPauseMenu);

        
    }
    
    public void OnEscape(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            
            SetPause();
        }

    }

    public void SetPause()
    {
        if(menuPausa.GetComponent<MenuPausa>().EscapeMenu()) {return;}
        
        isInPauseMenu = !isInPauseMenu;

        playerInput.gameObject.SetActive(!isInPauseMenu);   //esto desactiva el uso del celular

        fps.enabled = !isInPauseMenu;                        //falta desactivar  la navegación 

        timer.StopTime(isInPauseMenu);

        uIInput.gameObject.SetActive(isInPauseMenu);        //activa la navegacion ui

        menuPausa.gameObject.SetActive(isInPauseMenu);      //se ve el menu
    }
}
