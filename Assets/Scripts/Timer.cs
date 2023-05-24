using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float initialTime = 15f;
    [SerializeField] float normalTimeSpeed = 1f;
    [SerializeField] float fastTimeSpeed = 1.2f;
    [SerializeField] float superFastTimeSpeed = 2f;
    BatterySystem batterySystem;
    float currentTime;
    float timeSpeed;
    float previousTimeSpeed;
    
    private void Awake() 
    {
        batterySystem = GetComponent<BatterySystem>();    
    }
    
    void Start()
    {
        currentTime = initialTime;
        timeSpeed = normalTimeSpeed;
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }



    // Update is called once per frame
    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime * timeSpeed;
        }
        else
        {
            Debug.Log("perdiste");
        }
    }

    public void ChangeTimeSpeed(int state)
    {
        
        switch (state) 
        {
            
            case 0:
                timeSpeed = normalTimeSpeed;
                break;
            case 1:
                timeSpeed = fastTimeSpeed;
                //pequeña flecha
                break;
            case 2:
                timeSpeed = superFastTimeSpeed;
                //triple flecha
                break;
            case 3:
                timeSpeed = 0f;                 //pause
                //quitar flechas
                break;
            
        }
        batterySystem.SetArrows(state);

    }

    public void StopTime(bool state)
    {
        
        if(state)
        {
            previousTimeSpeed = timeSpeed;
            ChangeTimeSpeed(3);
        }
        else
        {
            timeSpeed = previousTimeSpeed;
            batterySystem.SetArrows(GetState());
            
            

        }
    }

    public float GetTimeRatio()
    {
        return currentTime/initialTime;
    }

    private int GetState()
    {
        if(timeSpeed == normalTimeSpeed)        { return 0; }
        else if(timeSpeed == fastTimeSpeed)     { return 1; }
        else if(timeSpeed == superFastTimeSpeed){ return 2; }
        else                                    { return 3; }
    }




}
