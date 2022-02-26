using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : Singleton<CameraManager>
{

    public Camera cam;
    public CinemachineVirtualCamera FirstPersonCameraState;
    public CinemachineVirtualCamera virtualCam;
    public CameraRig rig;

    public void TeleportCam(Vector3 location)
    {
        FirstPersonCameraState.ForceCameraPosition(location,cam.transform.rotation);
        cam.transform.position = location;
        rig.transform.position = location;
    }

    public void TeleportCam(Vector3 location, Quaternion rotation)
    {
        virtualCam.enabled = false;

        rig.SetRotation(rotation);
        //cam.transform.rotation = rotation;
        //cam.transform.position = location;
        rig.transform.position = location;

        virtualCam.enabled = true;

        FirstPersonCameraState.ForceCameraPosition(location, rotation);
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
