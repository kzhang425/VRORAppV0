using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCapture : MonoBehaviour
{
    // Start is called before the first frame update
    WebCamTexture tex;
    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        Renderer rend = this.GetComponentInChildren<Renderer>();
        tex = new WebCamTexture(devices[0].name);
        rend.material.mainTexture = tex;
        tex.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Color[] pixels = tex.GetPixels();

    }
}
