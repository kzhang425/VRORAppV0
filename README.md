# VRORAppV0
This repo contains a Unity project prototype with the aim to create a surgery-specific VR environment to optimize the surgical field of view with external cameras during tonsillectomy and adenoidectomy procedures.


This GitHub repository contains the core source code files that are used in the Unity application. The entire Unity project exceeds the data storage limit so could not be uploaded.

The `src` folder contains the following files: <br />
`CameraCapture.cs` - This script brings in the video stream from a connected usb device to be used as a video texture in the virtual environment. <br />
`ServerBehaviour.cs` - This script runs a server to transmit data through a local UDP connection. <br />
`ClientBehaviour.cs` - This script allows for the VR headset to receive the video data. <br />

<img width="387" alt="Screenshot 2023-02-24 005216" src="https://user-images.githubusercontent.com/65694382/221104523-88d25754-ba07-418c-8483-ca90ee3c8706.png">

## Software Flowchart
The flowchart below represents the general flow of data in a server-client setup.

![Software Flowchart](VROR_Brainstorm.png)
