using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Interactionhandler interactionhandler;
    
    public PlayerWalkingState walk;
    public PlayerClockState clock;
    public GameObject camPosition;

    public enum state
    {
        idle,
        walk,
        clock,
    }
    public state currentState = state.idle;

    /// <summary>
    /// Switch the current state to a new state
    /// </summary>
    /// <param name="newState"></param>
    public void switchState(state newState)
    {
        if (currentState != newState)
        {
            stateExit(currentState);
            currentState = newState;
            stateEnter(currentState);
        }
    }

    /// <summary>
    /// Exit a given state
    /// </summary>
    /// <param name="_stateToExit"></param>
    private void stateExit(state _stateToExit)
    {
        switch (_stateToExit)
        {
            case state.walk: walk.exit(); break;
            case state.clock: clock.exit(); break;
        }
    }

    /// <summary>
    /// Enter a given state
    /// </summary>
    /// <param name="_stateToEnter"></param>
    private void stateEnter(state _stateToEnter)
    {
        switch (_stateToEnter)
        {
            case state.walk: walk.enter(); break;
            case state.clock: clock.enter(); break;
        }
    }
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        interactionhandler = GetComponent<Interactionhandler>();
        walk = GetComponentInChildren<PlayerWalkingState>();

        walk.awake();
    }

    private void Start()
    {
        walk.start();

        InputManager.Instance.onInteractingEnter.AddListener(interact);
        InputManager.Instance.onFlashlightingUpdated.AddListener(flashlight);

        switchState(state.walk);
    }

    private void Update()
    {
        switch (currentState)
        {
            case state.walk: walk.update(); break;
            case state.clock: clock.update(); break;
        }
    }

    private void FixedUpdate()
    {
        switch (currentState)
        {
            case state.walk: walk.fixed_update(); break;
            case state.clock: clock.fixed_update(); break;
        }
    }

    private void LateUpdate()
    {
        switch (currentState)
        {
            case state.walk: walk.late_update(); break;
            case state.clock: clock.late_update(); break;
        }
    }


    
    #region inputActions
    public void interact()
    {
        switch (currentState)
        {
            case state.walk: walk.interact(); break;
            case state.clock: clock.interact(); break;
        }
    }

    public void flashlight(bool value)
    {
        switch (currentState)
        {
            case state.walk: walk.flashlight(value); break;
        }
    }
    #endregion
}
