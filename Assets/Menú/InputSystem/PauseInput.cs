using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInput : MonoBehaviour, Control.IPauseActions
{
    [SerializeField] GameObject menuPausa;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] UIInputsMP uIInput;
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
        isInPauseMenu = !isInPauseMenu;

        playerInput.gameObject.SetActive(!isInPauseMenu);
        uIInput.gameObject.SetActive(isInPauseMenu);

        menuPausa.gameObject.SetActive(isInPauseMenu);
    }
}
