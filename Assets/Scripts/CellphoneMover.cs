using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class CellphoneMover : MonoBehaviour
{
    
    [SerializeField] Transform downPos;
    [SerializeField] Transform upPos; 
    [SerializeField] float speed = 1f;
    [SerializeField] StarterAssetsInputs starterAssetsInputs;
    [SerializeField] GameObject batteryPanel;

    AppController appController;

    Timer timer;
    
    Quaternion initialPos;
    Quaternion finalPos;
    
   
    bool isUp = false;
    bool isMoving = false;
    bool isOn = false;


    private void Awake() {
        timer = FindObjectOfType<Timer>();
        appController = FindObjectOfType<AppController>();
    }

    
    void Start()
    {
        batteryPanel.SetActive(false);

    }

    
    void Update()
    {
            Move();       
        
    }

    private void Move()
    {
        if(!isMoving) {return;}

        transform.rotation = Quaternion.Lerp(transform.rotation, finalPos, speed* Time.deltaTime);

        if( transform.rotation == finalPos)
        {
            isMoving = false;
            starterAssetsInputs.cursorInputForLook = true;

            // si llega a destino y se prende el celular por lo tanto empieza
            //el mayor consumo de bateria nivel 1

            if(isUp)
            {
                SetCellOn();
            }
        }

    }

    public void initialMove()
    {
        if (this == null) { return;}
        initialPos = transform.rotation;
        if(isUp)
        {
            //el celular que estaba arriba se apaga y baja por lo tanto aca debería cambiar las velocidad de consumo 0
            //ya que el celular esta apagado.
            SetCellOff();


            finalPos = downPos.rotation;   
        }
        else
        {
            finalPos = upPos.rotation;
        }
        
        starterAssetsInputs.cursorInputForLook = false;
        starterAssetsInputs.look = new Vector2(0f,0f);

        isMoving = true;
        isUp = !isUp;
    }


    private void SetCellOn()
    {
        timer.ChangeTimeSpeed(1);
        batteryPanel.SetActive(true);
        isOn = true;
        

        //desencadenar animacion de prendido del celular (aparecen iconos o algo asi)
    }
    private void SetCellOff()
    {
        timer.ChangeTimeSpeed(0);
        appController.PawFinderOff();
        batteryPanel.SetActive(false);
        isOn = false;
        
        
        //desencadenar animacion de apagado de celular, la pantalla se vuelve negra
    }

    public bool GetScreenStete()
    {
        return isOn;
    }
}
