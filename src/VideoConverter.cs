using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class VideoConverter: MonoBehaviour
{
    // List of webcam-like devices the computer has access to
    WebCamDevice[] devices;
    WebCamDevice current_device;
    WebCamTexture tex;
    Renderer rend;
    public bool is_streaming; // true if there is a camera active

    private void Start()
    {
        devices = WebCamTexture.devices;
        current_device = devices[0];
        tex = new WebCamTexture(current_device.name);
        rend = this.GetComponentInChildren<Renderer>();
        rend.material.mainTexture = tex;
        tex.Play();
        

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchWebcam();
        }
        
    }

    // Call this function in conjunction with a if(Input.GetKeyUp(KeyCode.P)) or any other KeyCode
    protected void SwitchWebcam()
    {
        // Update list first to refresh list
        devices = WebCamTexture.devices;
        int? device_index = null;
        for (int i = 0; i < devices.Length; i++)
        {
            if (current_device.name == devices[i].name)
            {
                device_index = i;
                Debug.Log("Found device at index: " + device_index.ToString());
            }
        }

        // Now using the index, the button press should increment the device by one in the list
        // It can go to the next one or loop back around to the first one if it exists

        // If the device_index couldn't be found, then there is probably a problem and dont do anything
        if (!device_index.HasValue)
        {
            return;
        }

        // Loop back around if its already the last member of the list, otherwise, increment by one
        if (device_index.Value == devices.Length - 1)
        {
            Debug.Log("Looped back!");
            current_device = devices.First();
            tex.Stop();
        }
        else
        {
            current_device = devices[device_index.Value + 1];
            tex.Stop();
        }

        tex = new WebCamTexture(current_device.name);
        rend.material.mainTexture = tex;
        if (!tex.isPlaying)
        {
            tex.Play();
        }
    }
}
