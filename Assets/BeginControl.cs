using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BeginControl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) 
    {
        FirstPersonController instance = other.GetComponent<FirstPersonController>();

        if(instance == null) {return;}

        //ver si a futuro puedo ajustar la mirada y posicion juuusto frente al poste

        FindObjectOfType<InputCelu>().EnableControls();
        GetComponent<Collider>().enabled = false;
    
}
}
