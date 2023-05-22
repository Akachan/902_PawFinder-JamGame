using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioController : MonoBehaviour
{
    [SerializeField] AudioClip chanChanChan;
    [SerializeField] AudioMixer audioMixer;
    void Start()
    {
        GetComponent<AudioSource>().PlayOneShot(chanChanChan);        
    }


    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("MasterVolumen", Mathf.Log10(sliderValue)*20);
    }
}
