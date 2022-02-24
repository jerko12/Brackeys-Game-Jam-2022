using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalkingState : PlayerMovementState
{
    [SerializeField] private Transform relativeTransform;

    [SerializeField] private Vector3 moveDirectionLerped;

    public float moveSpeed = 3;
    public float lerpSpeed = 6;
    public override void update()
    {
        base.update();
        Move();
    }

    public void Move()
    {
        Vector2 inputDirection = InputManager.Instance.GetMoveDirection();
        Vector3 moveDirection = new Vector3(inputDirection.x, 0, inputDirection.y);
        moveDirection = moveDirection.RelativeVectorFlat(relativeTransform);
        

        moveDirectionLerped = Vector3.Lerp(moveDirectionLerped,moveDirection,Time.deltaTime * lerpSpeed);
        
        player.controller.Move(moveDirectionLerped * moveSpeed * Time.deltaTime);
    }

    public override void interact()
    {
        base.interact();
        player.interactionhandler.InteractWithCurrentInteractable();
    }

    public override void flashlight(bool value)
    {
        base.flashlight(value);
    }
}
