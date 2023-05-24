using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryNotifications : MonoBehaviour
{
    AudioSource audioSource;

    [Header("All Notifications")]
    [SerializeField] AudioClip lowBatterySFX;

    [Header("First Notification")]
    [SerializeField] float timeToReproduceNotification_1 = 1f;
    [SerializeField] AudioClip firstNotificationDP;  //dialogo del jugador: primera notificacion

    [Header("Second Notification")]
    [SerializeField] float timeToReproduceNotification_2 = 1f;
    

    [Header("Third Notification")]
    [SerializeField] float timeToReproduceNotification_3 = 1f;
    

    [Header("Fourth Notification")]
    [SerializeField] float timeToReproduceNotification_4 = 1f;
    

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();    
    }
    public void NotificationTrigger(int index)
    {
        audioSource.PlayOneShot(lowBatterySFX);
        switch (index)
        {
            case 0:
                StartCoroutine(FirstNotification());
                break;
            case 1:
                Debug.Log("Aun no se configuró la notificacion");
                break;
            case 2:
                Debug.Log("Aun no se configuró la notificacion");
                break;
            case 3:
                Debug.Log("Aun no se configuró la notificacion");
                break;
            default:
                Debug.Log("No es una notificación válida");
                break;
        }

    }


    //configurar cada notificacion por separado, porque algunas podrían no tener audios o modificar cosas completamente diferentes
    //Recordar en la ultima notificacion aumentar la velocidad de movimiento del pj
    IEnumerator FirstNotification()
    {
        yield return new WaitForSecondsRealtime(timeToReproduceNotification_1);
        audioSource.PlayOneShot(firstNotificationDP);
        // y todo el resto de cosas que pasen
    }
    IEnumerator SecondNotification()
    {
        yield return new WaitForSecondsRealtime(timeToReproduceNotification_2);

        // y todo el resto de cosas que pasen
    }
    IEnumerator ThirdNotification()
    {
        yield return new WaitForSecondsRealtime(timeToReproduceNotification_3);
 
        // y todo el resto de cosas que pasen
    }
    IEnumerator FourthNotification()
    {
        yield return new WaitForSecondsRealtime(timeToReproduceNotification_4);

        // y todo el resto de cosas que pasen
    }
}
