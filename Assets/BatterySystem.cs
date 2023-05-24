using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{

    [SerializeField] float initialBattery = 20f;
    [SerializeField] float firtsNotification = 15f;
    [SerializeField] float secondNotification = 10f;

    [SerializeField] float thirdNotification = 5f;
    [SerializeField] float lastNotification =2f;

    Timer timer;
    BatteryPanel batteryPanel;
    float currentBattery;

    private void Awake() 
    {
        timer = GetComponent<Timer>();
        batteryPanel = GetComponent<BatteryPanel>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calcular porcentaje de bateria
        currentBattery = timer.GetTimeRatio()*initialBattery;

        

    }

    public int GetCurrentBattery()
    {
        int intBattery = (int)currentBattery;
        return intBattery ;
    }

    public void SetArrows(int state)
    {
        switch (state)
        {
            case 1:
                batteryPanel.SetSmallArrow();
                break;
            case 2:
                batteryPanel.SetBigArrow();
                break;
            case 3:
                batteryPanel.WithoutArrows();
                break;
            default:
                //nada XD
                break;
        }
    }

    
}
