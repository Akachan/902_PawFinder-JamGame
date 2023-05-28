using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class CameraImgChanger : MonoBehaviour
{
    [SerializeField] Sprite defaultCameraScreen;
    [SerializeField] Sprite pawFinderDowloading;
    [SerializeField] float downloadDelay = 1.5f;
    [SerializeField] Sprite downloadComplete;
    [SerializeField] float destroyDelay;

    [SerializeField] GameObject particles;

    [SerializeField] SpriteRenderer flyer;
    [SerializeField] SpriteRenderer screenSaver;
    [SerializeField] Sprite newScreenSaver;

    InputCelu inputCelu;

   
    // Start is called before the first frame update
    private void Awake() {
        inputCelu = FindObjectOfType<InputCelu>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Download()
    {
        inputCelu.DisableControls();
        
        Debug.Log("LLEGASTE AL IMGCHANGER");
        StartCoroutine (ImgDownload());

        Destroy(particles);

        FindObjectOfType<Timer>().EnabledTime();

        StartCoroutine(DownCellphone());

        
    }
    IEnumerator ImgDownload()
    {
        Debug.Log("ENTRASTE A LA CORRUTINA");
        Image image = GetComponent<Image>();

        image.sprite = pawFinderDowloading;

        yield return new WaitForSecondsRealtime (downloadDelay);

        image.sprite = downloadComplete;

        yield return new WaitForSecondsRealtime (destroyDelay);

        image.sprite = defaultCameraScreen;


        flyer.enabled = true;

        screenSaver.sprite = newScreenSaver;    


        
    }

    IEnumerator DownCellphone()
    {
        yield return new WaitForSecondsRealtime(downloadDelay + destroyDelay + 3f);
        FindObjectOfType<CellphoneMover>().initialMove();

        inputCelu.EnableControls();
      
    }

    public float DowloadDialogueDelay()
    {
        return (downloadDelay);
    }
}
