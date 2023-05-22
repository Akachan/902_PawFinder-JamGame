using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuPausa : MonoBehaviour
{
    [SerializeField] AudioController audioController;
    [SerializeField] UIInputsMP uIInputs;
    MPEvents mPEvents;
    UIDocument pauseMenu;
    VisualElement root;

    //Botones Principales
    Button continueButton;
    Button restart;
    Button controls;
    Button quit;
    Button exit;
    Slider volume;
    VisualElement menuCont;
    VisualElement contCont;
    VisualElement exitCont;


    [SerializeField] float initialVolume = 0.5f;
    [SerializeField] float hopVolume = 0.1f;

    float currentVolume;
    bool isInControlsMenu = false;
    bool isVolumeFocus = false;
    



    private void OnEnable() 
    {
        pauseMenu = GetComponent<UIDocument>();
        mPEvents = GetComponent<MPEvents>();

        root = pauseMenu.rootVisualElement;

        //Contenedores
        menuCont = root.Q<VisualElement>("MenuContenedor"); //Lo que se oculta para mostrar los controles
        contCont = root.Q<VisualElement>("ContCont");       //cambia el fondo
        exitCont = root.Q<VisualElement>("ExitCont");       //El contenedor del boton exit

        //Botones Principales    
        continueButton = root.Q<Button>("Continue");
        restart = root.Q<Button>("Restart");
        controls = root.Q<Button>("Controls");
        quit = root.Q<Button>("Quit");
        exit = root.Q<Button>("Exit");

        volume = root.Q<Slider>("Volume");
        volume.lowValue = 0.001f;
        volume.highValue = 1f;
        volume.value = initialVolume;

        //EVENTOS
        
        continueButton.RegisterCallback<ClickEvent>(ContinueButtonClick);
        continueButton.RegisterCallback<FocusEvent>(ContinueButton);
        continueButton.RegisterCallback<FocusOutEvent>(ContinueButtonOut);

        restart.RegisterCallback<ClickEvent>(RestartButtonClick);
        restart.RegisterCallback<FocusEvent>(RestartButton);
        restart.RegisterCallback<FocusOutEvent>(RestartButtonOut);

        controls.RegisterCallback<ClickEvent>(ControlsButtonClick);
        controls.RegisterCallback<FocusEvent>(ControlsButton);
        controls.RegisterCallback<FocusOutEvent>(ControlsButtonOut);
       
        quit.RegisterCallback<ClickEvent>(QuitButtonClick);        
        quit.RegisterCallback<FocusOutEvent>(QuitButtonsOut);
        quit.RegisterCallback<FocusEvent>(QuitButtons);

        exit.RegisterCallback<ClickEvent>(ExitButtonClick);        
        exit.RegisterCallback<FocusOutEvent>(ExitButtonsOut);
        exit.RegisterCallback<FocusEvent>(ExitButtons);

        volume.RegisterCallback<FocusEvent>(VolumeSlider);
        volume.RegisterCallback<FocusOutEvent>(VolumeSliderOut);

        continueButton.Focus();
        
    }



    private void Start() 
    {
        continueButton.Focus();
        SetInvisible(exitCont);
        currentVolume = initialVolume;
    }
    private void Update() 
    {   
        VolumeModifier(uIInputs.GetXNavigation());
        Debug.Log(volume.value);   
    }


    //Play Button*****************************
    private void ContinueButtonClick(ClickEvent evt)
    {
      
        mPEvents.InvokeOnSelect();
    }
    private void ContinueButton(FocusEvent evt)
    {
        mPEvents.ClearOnSelect();
        mPEvents.OnSelect += mPEvents.ContinueGame;
    }
    private void ContinueButtonOut(FocusOutEvent evt)
    {
       mPEvents.OnSelect -= mPEvents.ContinueGame;
    }
    
    //Restart Button******************************
    private void RestartButtonClick(ClickEvent evt)
    {
        
    }
    private void RestartButton(FocusEvent evt)
    {
      
    }
    private void RestartButtonOut(FocusOutEvent evt)
    {
    
    }


    //Config Button *****************************
    private void ControlsButtonClick(ClickEvent evt)
    {

        mPEvents.InvokeOnSelect();
        
    }
    private void ControlsButton(FocusEvent evt)
    {
        mPEvents.ClearOnSelect();
        mPEvents.OnSelect += SetControlsView;
        mPEvents.OnSelect += mPEvents.ViewControls;
    }
    private void ControlsButtonOut(FocusOutEvent evt)
    {
        mPEvents.OnSelect -= SetControlsView;
        mPEvents.OnSelect -= mPEvents.ViewControls; 
    }


    //Quit Button******************************
    private void QuitButtonClick(ClickEvent evt)
    {

        mPEvents.InvokeOnSelect();
        continueButton.Focus();
    }      
    private void QuitButtons(FocusEvent evt)
    {
        mPEvents.ClearOnSelect();
        mPEvents.OnSelect += mPEvents.QuitGame;
    }
    private void QuitButtonsOut(FocusOutEvent evt)
    {
        mPEvents.OnSelect -= mPEvents.QuitGame;
    }

    //ExitButton*******************************
    private void ExitButtonClick(ClickEvent evt)
    {
        mPEvents.InvokeOnSelect();
    }
    private void ExitButtons(FocusEvent evt)
    {
        mPEvents.ClearOnSelect();
        mPEvents.OnSelect += RemoveControlsView;
    }
    private void ExitButtonsOut(FocusOutEvent evt)
    {
        mPEvents.OnSelect -= RemoveControlsView;

    }

    //VolumeSlider******************************
        private void VolumeSlider(FocusEvent evt)
    {
        isVolumeFocus = true;
    }

    private void VolumeSliderOut(FocusOutEvent evt)
    {
        isVolumeFocus = false;
    }


 

    //Modificadores
    public void SetInvisible(VisualElement element)
    {   
        element.AddToClassList("invisible");
    }
    public void SetVisible(VisualElement element)
    {   
        element.RemoveFromClassList("invisible");
    }


    public void SetControlsView() 
    {   
        SetInvisible(menuCont);
        SetVisible(exitCont);

        contCont.AddToClassList("controls");

        isInControlsMenu = true;
        
        exit.Focus();
    }
    public void RemoveControlsView()
    {
        SetVisible(menuCont);
        SetInvisible(exitCont);

        contCont.RemoveFromClassList("controls");

        isInControlsMenu = false;

        continueButton.Focus();    
    }

    public void EscapeMenu()
    {
        if(isInControlsMenu)
        {
            mPEvents.ClearOnSelect();
            RemoveControlsView();
        }
    }

    public void VolumeModifier(float value)
    {
        if(isVolumeFocus)
        {
            volume.value += hopVolume * value * Time.deltaTime;
            audioController.SetVolume(volume.value);
        }
    }



}
