using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float verticalSpeed = 7.0f;

    [SerializeField] private Vector2 verticalClamp = new Vector2(-85,85);

    InputManager inputManager;
    private Vector3 currentRotation;

    protected override void Awake()
    {
        currentRotation = transform.localEulerAngles;
        inputManager = InputManager.Instance;
        base.Awake();
        
    }


    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = InputManager.Instance.GetLookDelta();
                currentRotation.x += deltaInput.x * horizontalSpeed * Time.deltaTime;
                currentRotation.y += deltaInput.y * verticalSpeed * Time.deltaTime;
                currentRotation.y = Mathf.Clamp(currentRotation.y, verticalClamp.x, verticalClamp.y);

                state.RawOrientation = Quaternion.Euler(currentRotation.y,currentRotation.x,0f);
            }
        }   
    }
}
