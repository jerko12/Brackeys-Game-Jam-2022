using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Player player;
    
    [SerializeField] private Transform followTarget;

    [SerializeField] private float horizontalSpeed = 10.0f;
    [SerializeField] private float verticalSpeed = 7.0f;

    [SerializeField] private Vector2 verticalClamp = new Vector2(-85, 85);
    [SerializeField] private Vector2 lerpSpeed = new Vector2(6, 4);

    [SerializeField] private Vector3 currentRotation;
    [SerializeField] private Vector3 currentRotationLerped;

    public void SetRotation(Quaternion rotation)
    {
        currentRotation.x += rotation.eulerAngles.y;
        currentRotationLerped.x += rotation.eulerAngles.y;
        //Vector3 currentRotationVertical = new Vector3(0,currentRotation.y,0);
        //currentRotationVertical = rotation * currentRotationVertical;
        //currentRotation = new Vector3(currentRotation.x, currentRotationVertical.y, 0);

        Debug.Log("Y Rotation: " + rotation.eulerAngles.y);
        //currentRotationVertical = new Vector3(0,currentRotationLerped.y,0);
        //currentRotationVertical = rotation * currentRotationVertical;
        //currentRotationLerped = new Vector3(currentRotationLerped.x, currentRotationVertical.y,.0f);

    }

    void Update()
    {
        if (player.currentState == Player.state.clock)
        {
            return;
        }
        
        Vector2 deltaInput = InputManager.Instance.GetLookDelta();


        currentRotation.x += deltaInput.x * horizontalSpeed * Time.deltaTime;
        currentRotation.y -= deltaInput.y * verticalSpeed * Time.deltaTime;
        currentRotation.y = Mathf.Clamp(currentRotation.y, verticalClamp.x, verticalClamp.y);

        currentRotationLerped.x = Mathf.Lerp(currentRotationLerped.x, currentRotation.x, Time.deltaTime * lerpSpeed.y);
        currentRotationLerped.y = Mathf.Lerp(currentRotationLerped.y, currentRotation.y, Time.deltaTime * lerpSpeed.x);



        transform.rotation = Quaternion.Euler(currentRotationLerped.y, currentRotationLerped.x, 0f);
    }

    private void LateUpdate()
    {
        transform.position = followTarget.position;
    }
}
