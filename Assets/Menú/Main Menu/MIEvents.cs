using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MIEvents : MonoBehaviour
{
    public event Action OnSelect;
    MenuInicio menuInicio;
    private void Awake() {
        menuInicio = GetComponent<MenuInicio>();
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
    public void NewGame()
    {
        Debug.Log("querés empezar un nuevo juego");
        SceneManager.LoadScene("PawFinderMainGame");
    }

    public void ViewControls()
    {
    }

    public void QuitGame()
    {
        Debug.Log("queres salir del juego");
        Application.Quit();
    }

    public void EscapeMenu()
    {
        menuInicio.EscapeMenu();

    }
    public void VolumeModifier(float value)
    {
        menuInicio.VolumeModifier(value);
    }
}
