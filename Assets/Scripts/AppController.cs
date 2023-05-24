using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField] GameObject appCamera;
    [SerializeField] CellphoneMover cellphoneMover;
    [SerializeField] Timer timer;
    bool isCameraOn = false;
    void Start()
    {
        appCamera.SetActive(isCameraOn);
    }

    void Update()
    {
        
    }

    public void PawFinderOnOff()
    {  
        if(!cellphoneMover.GetScreenStete()) {return;}
        
        isCameraOn = !isCameraOn;

        if (appCamera == null) {return;} 
        appCamera.SetActive(isCameraOn);

        if(isCameraOn)
        {
            timer.ChangeTimeSpeed(2);
        }
        else
        {
            timer.ChangeTimeSpeed(1);
        }
    }


    public void PawFinderOff()
    {
        if(!isCameraOn) {return;}
        isCameraOn = false;
        appCamera.SetActive(isCameraOn);
    }

    public bool GetCameraState()
    {
        return isCameraOn;
    }





    
}
