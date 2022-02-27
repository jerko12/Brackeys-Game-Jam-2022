using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    public Player player;
    public void Teleport(Vector3 position)
    {
        player.controller.enabled = false;
        player.transform.position = position;
       
        CameraManager.Instance.TeleportCam(player.camPosition.transform.position);
        
        player.controller.enabled = true;
    }
    
    public void Teleport(Vector3 position,Quaternion rotation)
    {
        player.controller.enabled = false;
        player.transform.position = position;
        player.walk.RotateMoveDirection(rotation);
        CameraManager.Instance.TeleportCam(player.camPosition.transform.position,rotation);
        player.controller.enabled = true;
    }
    public override void Awake()
    {
        base.Awake();
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
