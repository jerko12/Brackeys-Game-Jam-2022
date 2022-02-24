using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{

    public void Selected();
    public void Deselected();
    public void Interact();
}
