using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class BatteryPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI batteryTxt;
    [SerializeField] GameObject smallArrow;
    [SerializeField] GameObject bigArrow;
    [SerializeField] Image baterryImg;
    BatterySystem batterySystem;
    int currentBattery;

    private void Awake() {
        batterySystem = GetComponent<BatterySystem>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetBatteryPercent();
        SetBatteryFilled();

    }

    private void SetBatteryFilled()
    {
        baterryImg.fillAmount = currentBattery/100f;
    }


    public void WithoutArrows()
    {
        smallArrow.SetActive(false);
        bigArrow.SetActive(false);
    }
    public void SetSmallArrow()
    {
        smallArrow.SetActive(true);
        bigArrow.SetActive(false);
    }
        public void SetBigArrow()
    {
        smallArrow.SetActive(false);
        bigArrow.SetActive(true);
    }

    private void SetBatteryPercent()
    {
        currentBattery = batterySystem.GetCurrentBattery();
        batteryTxt.text = $"{currentBattery.ToString()}%";
    }
}
