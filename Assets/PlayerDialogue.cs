using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] DialogueSO downloadApp;
    [SerializeField] List<DialogueSO> notifications = new List<DialogueSO>();
    [SerializeField] TextMeshProUGUI subtitleText;
    AudioSource audioSource;    

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public void NotificationON(int index, AudioSource origin)
    {
        AudioClip audioClip = notifications[index].GetAudioClip();
        origin.PlayOneShot(audioClip);

        float captionTime = notifications[index].GetCaptionTime();
        string dialogueText = notifications[index].GetDialogueText();

        StartCoroutine(SetSubtitles(captionTime, dialogueText ));

    }
    public void DownloadApp()
    {

        Debug.Log("llego aqui");

        AudioClip audioClip = downloadApp.GetAudioClip();
        audioSource.PlayOneShot(audioClip);

        float captionTime = downloadApp.GetCaptionTime();
        string dialogueText = downloadApp.GetDialogueText();

        StartCoroutine(SetSubtitles(captionTime, dialogueText ));
    }
        public void SfxON(DialogueSO sfx, AudioSource origin)
    {
        AudioClip audioClip = sfx.GetAudioClip();
        origin.PlayOneShot(audioClip);

        float captionTime = sfx.GetCaptionTime();
        string dialogueText = sfx.GetDialogueText();

        StartCoroutine(SetSubtitles(captionTime, dialogueText ));

    }

    IEnumerator SetSubtitles(float delay, string text)
    {
        subtitleText.text = text;
        yield return new WaitForSecondsRealtime (delay);
        subtitleText.text = "";


    }

}
