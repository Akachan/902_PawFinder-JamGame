using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{
    
    [SerializeField] bool isLightning = false;
    [SerializeField] float flashHop = 1f;
    float intensity = 0f;
    float direction = 1;
    MeshRenderer meshRenderer;
    Color color;
    

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        color = meshRenderer.material.color;
        meshRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        FlashShutter();
        
    }
    public void FlashShutter()
    {
        if(isLightning)
        {   
            meshRenderer.enabled = true;

            intensity = Mathf.Clamp (intensity + flashHop * Time.deltaTime * direction, 0, 1);
            SetAlpha(intensity );
            if (intensity == 1)
            {
                direction = -1;
            }
            if( intensity == 0)
            {
                isLightning = false;
                intensity = 0f;
                direction = 1;
            }
            
        }
        else meshRenderer.enabled = false;
    }

    private void SetAlpha(float alpha)
    {
        color.a = intensity;
        meshRenderer.material.color = color;
    }

    public void SetFlash()
    {
        isLightning = true;
    }
}
