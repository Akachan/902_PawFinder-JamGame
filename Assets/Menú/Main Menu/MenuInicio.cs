using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuInicio : MonoBehaviour
{
    [SerializeField] AudioController audioController;
    MIEvents mIEvents;
    UIInputsMI uIInputs;
    UIDocument mainMenu;
    VisualElement root;

    //Botones Principales
    Button play;
    Button controls;
    Button quit;
    Button exit;
    Slider volume;
    Label loading;
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
        mainMenu = GetComponent<UIDocument>();
        mIEvents = GetComponent<MIEvents>();
        uIInputs = GetComponent<UIInputsMI>();
        root = mainMenu.rootVisualElement;

        //Contenedores
        menuCont = root.Q<VisualElement>("MenuContenedor"); //Lo que se oculta para mostrar los controles
        contCont = root.Q<VisualElement>("ContCont");       //cambia el fondo
        exitCont = root.Q<VisualElement>("ExitCont");       //El contenedor del boton exit

        //Botones Principales    
        play = root.Q<Button>("Play");
        controls = root.Q<Button>("Controls");
        quit = root.Q<Button>("Quit");
        exit = root.Q<Button>("Exit");

        volume = root.Q<Slider>("Volume");
        volume.lowValue = 0.001f;
        volume.highValue = 1f;
        volume.value = initialVolume;
        
        loading = root.Q<Label>("Loading");



        //EVENTOS
        
        play.RegisterCallback<ClickEvent>(PlayButtonClick);
        play.RegisterCallback<FocusEvent>(PlayButton);
        play.RegisterCallback<FocusOutEvent>(PlayButtonOut);

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
        
    }



    private void Start() 
    {
        play.Focus();
        SetInvisible(exitCont);
        currentVolume = initialVolume;
    }
    private void Update() 
    {   
        VolumeModifier(uIInputs.GetXNavigation());
        Debug.Log(volume.value);   
    }


    //Play Button*****************************
    private void PlayButtonClick(ClickEvent evt)
    {
      
        mIEvents.InvokeOnSelect();
    }
    private void PlayButton(FocusEvent evt)
    {
        mIEvents.ClearOnSelect();
        mIEvents.OnSelect += mIEvents.NewGame;
    }
    private void PlayButtonOut(FocusOutEvent evt)
    {
       mIEvents.OnSelect -= mIEvents.NewGame;
    }


    //Config Button *****************************
    private void ControlsButtonClick(ClickEvent evt)
    {

        mIEvents.InvokeOnSelect();
        
    }
    private void ControlsButton(FocusEvent evt)
    {
        mIEvents.ClearOnSelect();
        mIEvents.OnSelect += SetControlsView;
        mIEvents.OnSelect += mIEvents.ViewControls;
    }
    private void ControlsButtonOut(FocusOutEvent evt)
    {
        mIEvents.OnSelect -= SetControlsView;
        mIEvents.OnSelect -= mIEvents.ViewControls; 
    }


    //Quit Button******************************
    private void QuitButtonClick(ClickEvent evt)
    {

        mIEvents.InvokeOnSelect();
        play.Focus();
    }      
    private void QuitButtons(FocusEvent evt)
    {
        mIEvents.ClearOnSelect();
        mIEvents.OnSelect += mIEvents.QuitGame;
    }
    private void QuitButtonsOut(FocusOutEvent evt)
    {
        mIEvents.OnSelect -= mIEvents.QuitGame;
    }

    //ExitButton*******************************
    private void ExitButtonClick(ClickEvent evt)
    {
        mIEvents.InvokeOnSelect();
    }
    private void ExitButtons(FocusEvent evt)
    {
        mIEvents.ClearOnSelect();
        mIEvents.OnSelect += RemoveControlsView;
    }
    private void ExitButtonsOut(FocusOutEvent evt)
    {
        mIEvents.OnSelect -= RemoveControlsView;

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

        play.Focus();    
    }

    public void EscapeMenu()
    {
        if(isInControlsMenu)
        {
            mIEvents.ClearOnSelect();
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

    public void LoadingMessage()
    {
        SetInvisible(play);
        SetInvisible(controls);
        SetInvisible(volume);
        SetInvisible(quit);
        SetVisible(loading);
    }


}
