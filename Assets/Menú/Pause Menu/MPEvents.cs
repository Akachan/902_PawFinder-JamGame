using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MPEvents : MonoBehaviour
{
    [SerializeField] PauseInput pauseInput;
    public event Action OnSelect;
    MenuPausa menuPausa;

    private void Awake() {
        menuPausa = GetComponent<MenuPausa>();
    }


    public void InvokeOnSelect()
    {
        if(OnSelect != null)
        {
            OnSelect.Invoke();
        }
    }

    public void ClearOnSelect()
    {
        if(OnSelect != null)
        {
            Debug.Log("se debió desfocusear todo");
            OnSelect = null;
        }   
    }
    //Acciones de botones
    public void ContinueGame()
    {
        Debug.Log("Querés seguir jugando");
        pauseInput.SetPause();
        ClearOnSelect();
        
        //SceneManager.LoadScene("MainGame");
    }

    public void ViewControls()
    {
    }

    public void QuitGame()
    {
        Debug.Log("queres salir del juego");
        SceneManager.LoadScene("MenuInicio");
    }

    public void EscapeMenu()
    {
        menuPausa.EscapeMenu();

    }
    public void VolumeModifier(float value)
    {
        menuPausa.VolumeModifier(value);
    }
}
