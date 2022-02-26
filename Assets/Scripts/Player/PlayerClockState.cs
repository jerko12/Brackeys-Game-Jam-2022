using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerClockState : MonoBehaviour
{
    [SerializeField] protected Player player;
    
    public Clock selectedClock;
    public CinemachineVirtualCamera playerCamera;
    #region state

    public virtual void enter()
    {
        // Switch camera to clock cam
        selectedClock.clockCamera.Priority = 60;
        playerCamera.Priority = 1;
    }

    public virtual void exit()
    {
        //Switch back camera to player
        selectedClock.clockCamera.Priority = 1;
        playerCamera.Priority = 60;
    }
    #endregion

    #region behaviour
    public virtual void awake() { }
    public virtual void start() { }

    public virtual void update()
    {
        
        Vector2 inputDirection = InputManager.Instance.GetMoveDirection();
        if (!selectedClock.IsRotating() && inputDirection.magnitude > 0.5)
        {
            if (inputDirection.x > 0)
            {
                selectedClock.Next();
            }
            else
            {
                selectedClock.Previous();
            }
            
        }
        
    }
    public virtual void fixed_update() { }
    public virtual void late_update() { }

    public void setSelectedClock(Clock clock)
    {
        selectedClock = clock;
    }
    #endregion

    #region input

    public virtual void interact()
    {
        player.switchState(Player.state.walk);
    }
    
    public virtual void flashlight(bool value) {}
    #endregion
}
