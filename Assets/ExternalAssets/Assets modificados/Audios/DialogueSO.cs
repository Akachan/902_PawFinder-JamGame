using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Crear Diálogo", fileName = "NewDialogue")]
public class DialogueSO : ScriptableObject
{
    [SerializeField] AudioClip dialogueClip;
    [SerializeField] [TextArea(1,5)] string dialogueText;
    [SerializeField] [Tooltip ("Es el tiempo que está el subtitulo en pantalla")] float captionTime = 2f;

    public AudioClip GetAudioClip()
    {
        return dialogueClip;
    }

    public string GetDialogueText()
    {
        return dialogueText;
    }
    public float GetCaptionTime()
    {
        return captionTime;
    }

}
