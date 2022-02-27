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
    public Animator animator;
    public AudioSource openSound;
    public AudioSource closeSound;
    
    private static readonly int Opening = Animator.StringToHash("opening");
    private static readonly int Closing = Animator.StringToHash("closing");

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
        //if (opened) return;
        Debug.Log("Door Interacted");
        //LevelManager.Instance.layout.PlaceHallway(1, hallwayLocation.x, hallwayLocation.y, transform.rotation);
        onInteraction?.Invoke(this);
        if (!opened) Open();
       // else Close();


    }

    public void Open()
    {
        //door.SetActive(false);
        opened = true;
        col.enabled = false;
        if (!animator.GetBool(Opening))
        {
            Debug.Log("Opening door");
            openSound.Play();
            animator.SetBool(Opening, true);
        }
        
    }

    public void Close()
    {
        //door.gameObject.SetActive(false);
        opened = false;
        col.enabled = true;
        if (animator.GetBool(Opening))
        {
            animator.SetBool(Opening, false);
        }
    }

    public void Opened()
    {
        //animator.SetBool(Opening, false);
    }

    public void Closed()
    {
        closeSound.Play();
        //animator.SetBool(Closing, false);
    }
}
