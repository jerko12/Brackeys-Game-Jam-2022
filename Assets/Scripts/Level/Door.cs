using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour,IInteractable
{
    public Vector2Int doorLocation = Vector2Int.zero;
    public Vector2Int additiveDoorLocation = Vector2Int.zero;
    public UnityEvent<Door> onInteraction;
    public Collider col;

    public bool opened = false;
    public bool isLocked = false;

    [SerializeField] private GameObject door;

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
        door.SetActive(false);
        col.enabled = false;
    }

    public void Close()
    {
        door.gameObject.SetActive(false);
        col.enabled = false;
    }
}
