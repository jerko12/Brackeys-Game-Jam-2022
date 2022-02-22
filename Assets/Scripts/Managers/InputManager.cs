using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    private Vector2 moveDirection = Vector2.zero;
    private Vector2 lookDelta = Vector2.zero;

    private bool isInteractionPressed = false;
    private bool isFlashlightPressed = false;

    public UnityEvent<Vector2> onMoveDirectionUpdated;
    public UnityEvent<Vector2> onLookDeltaUpdated;
    public UnityEvent onInteractingEnter;
    public UnityEvent onInteractingExit;
    public UnityEvent onFlashlightingEnter;
    public UnityEvent<bool> onFlashlightingUpdated;
    public UnityEvent onFlashlightingExit;

    private InputControls input;

    public override void Awake()
    {
        base.Awake();
        input = new InputControls();
    }


    /*
    public void OnMove(Vector2 _moveDirection)
    {
        moveDirection = _moveDirection;
    }
    public void OnLook(Vector2 _lookDelta)
    {
        lookDelta = _lookDelta;
    }

    public void OnInteraction(bool _isInteractionPressed)
    {
        isInteractionPressed = _isInteractionPressed;
    }

    public void OnFlashlight(bool _isFlashlightPressed)
    {
        isFlashlightPressed = _isFlashlightPressed;
    }
    */

    private void Start()
    {
        // Move
        input.Game.Move.performed += ctx => onMoveDirectionUpdated?.Invoke(ctx.ReadValue<Vector2>());
        
        // Look
        input.Game.Look.performed += ctx => onLookDeltaUpdated?.Invoke(ctx.ReadValue<Vector2>());
        
        // Interact
        input.Game.Interact.performed += ctx => { if (ctx.ReadValue<float>() > .85f) onInteractingEnter?.Invoke(); };
        
        // Flashlight
        input.Game.Flashlight.performed += ctx => Flashlight(ctx);
        input.Game.Flashlight.canceled += ctx => Flashlight(ctx);
        

        // Enable the input
        input.Enable();
    }


    public void Flashlight(InputAction.CallbackContext ctx)
    {
        if (ctx.ReadValue<float>() > .85f)
        {
            onFlashlightingUpdated?.Invoke(true);
        }
        else
        {
            onFlashlightingUpdated?.Invoke(false);
        }
    }

    public Vector2 GetMoveDirection()
    {
        return input.Game.Move.ReadValue<Vector2>();
    }

    public Vector2 GetLookDelta()
    {
        return input.Game.Look.ReadValue<Vector2>();
    }

    public bool GetInteractionPressed()
    {
        return input.Game.Interact.ReadValue<float>() > .85f;
    }

    public bool GetFlashlightPressed()
    {
        return input.Game.Flashlight.ReadValue<float>() > .85f;
    }
}
