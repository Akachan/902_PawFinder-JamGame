using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppShooter : MonoBehaviour
{
    [SerializeField] Camera appCamera;
    [SerializeField] float rangeCamera = 20f;
    AppController appController;
    RaycastHit hit;


    private void Awake() {
        appController = GetComponent<AppController>();
    }

    void Start()
    {
        
    }


    void Update()
    {
        

    }

    public void PerformRaycast()
    {
        if (!appController.GetCameraState()) { return; } //si la camara no está encendida

        if(appCamera == null) {return;}

        if(!Physics.Raycast(appCamera.transform.position, appCamera.transform.forward, //si está muy lejos del objetivo
                            out hit, rangeCamera)) { return;}

        Physics.Raycast(appCamera.transform.position, appCamera.transform.forward, out hit, rangeCamera);

        TargetEvent target = hit.transform.GetComponent<TargetEvent>();



        if (target != null)
        {
            //setear una animación o un simbolo de que el objeto es shotteable o no...
            target.StartEvent();
            target.GetComponent<Collider>().enabled = false;
        }
        else
        {
            Debug.Log("aquí no hay nada");
        }
    }

    private void OnDrawGizmos() 
    {
        
        Gizmos.color = Color.green;
        Gizmos.DrawRay(appCamera.transform.position, appCamera.transform.forward * rangeCamera);
    }
}
