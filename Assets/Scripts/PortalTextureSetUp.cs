using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetUp : MonoBehaviour
{
    public Camera cameraB;

    public Material CameraMatB;

    public Camera cameraG;

    public Material CameraMatG;

    // Start is called before the first frame update
    void Start()
    {
        if(cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatB.mainTexture = cameraB.targetTexture;

        if (cameraG.targetTexture != null)
        {
            cameraG.targetTexture.Release();
        }
        cameraG.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        CameraMatG.mainTexture = cameraG.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
