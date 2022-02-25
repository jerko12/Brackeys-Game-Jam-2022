using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour,IInteractable
{
    public Vector2Int doorLocation = Vector2Int.zero;
    public UnityEvent<Quaternion> onInteraction;
    public bool opened = false;

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
        if (opened) return;
        Debug.Log("Door Interacted");
        //LevelManager.Instance.layout.PlaceHallway(1, hallwayLocation.x, hallwayLocation.y, transform.rotation);
        onInteraction?.Invoke(transform.rotation);
        gameObject.SetActive(false);
        opened = true;
    }
}
