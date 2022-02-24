using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{

    public void Selected()
    {
        Debug.Log("Door Selected");
    }

    public void Deselected()
    {
        Debug.Log("Door Deselected");
    }

    public void Interact()
    {
        Debug.Log("Door Interacted");
    }
}
