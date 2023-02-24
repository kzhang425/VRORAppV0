using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        Renderer rend = this.GetComponentInChildren<Renderer>();
        WebCamTexture tex = new WebCamTexture(devices[0].name);
        rend.material.mainTexture = tex;
        tex.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
