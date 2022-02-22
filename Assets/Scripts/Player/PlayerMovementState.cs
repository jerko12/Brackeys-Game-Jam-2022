using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : MonoBehaviour
{
    [SerializeField] protected Player player;

    #region state
    public virtual void enter() { }
    public virtual void exit() { }
    #endregion

    #region behaviour
    public virtual void awake() { }
    public virtual void start() { }
    public virtual void update() { }
    public virtual void fixed_update() { }
    public virtual void late_update() { }
    #endregion

    #region input
    public virtual void interact() {}
    public virtual void flashlight(bool value) {}
    #endregion
}
