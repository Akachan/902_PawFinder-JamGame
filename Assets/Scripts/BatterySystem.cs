using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{

    [SerializeField] float initialBattery = 20f;
    [SerializeField] List<float> batteryPercentNotifications = new List<float>();

    Timer timer;
    BatteryPanel batteryPanel;
    BatteryNotifications batteryNotifications;
    float currentBattery;
    int currentFase = 0;

    private void Awake() 
    {
        timer = GetComponent<Timer>();
        batteryPanel = GetComponent<BatteryPanel>();
        batteryNotifications = GetComponent<BatteryNotifications>();
    }
    void Start()
    {
        
    }

   
    void Update()
    {
       
        currentBattery = timer.GetTimeRatio() * initialBattery;

    
        SendNotifications();

    }

    private void SendNotifications()
    {
        if (currentFase == batteryPercentNotifications.Count) { return; }

        if (currentBattery <= batteryPercentNotifications[currentFase] + 1)
        {
            //desencadenar eventos
            Debug.Log($"salto la notificacion del {batteryPercentNotifications[currentFase]}");
            batteryNotifications.NotificationTrigger(currentFase);


            currentFase++;
        }
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
