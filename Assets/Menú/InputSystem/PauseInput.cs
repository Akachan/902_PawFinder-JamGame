using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class PauseInput : MonoBehaviour, Control.IPauseActions
{
    [SerializeField] GameObject menuPausaGO;
    [SerializeField] InputCelu playerInput;
    [SerializeField] UIInputsMP uIInput;
    [SerializeField] FirstPersonController fps;
    [SerializeField] Timer timer;
    Control control;
    MenuPausa menuPausa;

    bool isInPauseMenu = false;
    
    private void Awake() {
        menuPausa = menuPausaGO.GetComponent<MenuPausa>();
    }

    private void Start()
    {
        
        Cursor.visible = false;

        control = new Control();
        control.Pause.SetCallbacks(this);
        control.Pause.Enable();

        playerInput.gameObject.SetActive(!isInPauseMenu);
        uIInput.gameObject.SetActive(isInPauseMenu);

        menuPausaGO.SetActive(isInPauseMenu);

        
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
        if(menuPausa.EscapeMenu()) {return;}
        
        isInPauseMenu = !isInPauseMenu;

        if(playerInput == null) {return;}

        playerInput.gameObject.SetActive(!isInPauseMenu);   //esto desactiva el uso del celular

        fps.enabled = !isInPauseMenu;                        //falta desactivar  la navegación 

        timer.StopTime(isInPauseMenu);

        uIInput.gameObject.SetActive(isInPauseMenu);        //activa la navegacion ui

        menuPausaGO.gameObject.SetActive(isInPauseMenu);      //se ve el menu
    }


}
