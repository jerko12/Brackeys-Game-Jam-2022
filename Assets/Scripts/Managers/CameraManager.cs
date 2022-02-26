using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{

    public Camera cam;
    public CinemachineVirtualCamera playerCamera;
    public CinemachineVirtualCamera clockCamera;

    public void SetState(string newState)
    {
        switch (newState)
        {
            case "clock":
                playerCamera.Priority = 1;
                clockCamera.Priority = 60;
                break;
            default:
                playerCamera.Priority = 60;
                clockCamera.Priority = 1;
                break;
        }
    }


    public CameraRig rig;

    public void TeleportCam(Vector3 location)
    {
        playerCamera.ForceCameraPosition(location, cam.transform.rotation);
        cam.transform.position = location;
        rig.transform.position = location;
    }

    public void TeleportCam(Vector3 location, Quaternion rotation)
    {
        playerCamera.enabled = false;

        rig.SetRotation(rotation);
        //cam.transform.rotation = rotation;
        //cam.transform.position = location;
        rig.transform.position = location;

        playerCamera.enabled = true;

        playerCamera.ForceCameraPosition(location, rotation);
    }

    public override void Awake()
    {
        base.Awake();
        cam = Camera.main;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}