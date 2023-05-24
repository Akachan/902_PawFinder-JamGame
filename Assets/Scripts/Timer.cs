using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float initialTime = 15f;
    [SerializeField] float normalTimeSpeed = 1f;
    [SerializeField] float fastTimeSpeed = 1.2f;
    [SerializeField] float superFastTimeSpeed = 2f;
    float currentTime;
    float timeSpeed;
    float previousTimeSpeed;
    
    
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
                break;
            case 2:
                timeSpeed = superFastTimeSpeed;
                break;
            case 3:
                timeSpeed = 0f;
                break;
            
        }

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
        }
    }
}
