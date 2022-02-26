using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour,IInteractable
{
    public Vector2Int doorLocation = Vector2Int.zero;
    public Vector2Int additiveDoorLocation = Vector2Int.zero;
    public UnityEvent<Door> onInteraction;
    public bool opened = false;
    public bool isLocked = false;

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
        if (isLocked) {Debug.Log("Door is locked!"); return; }
        if (opened) return;
        Debug.Log("Door Interacted");
        //LevelManager.Instance.layout.PlaceHallway(1, hallwayLocation.x, hallwayLocation.y, transform.rotation);
        onInteraction?.Invoke(this);
        Open();
        opened = true;
    }

    public void Open()
    {
        gameObject.SetActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
