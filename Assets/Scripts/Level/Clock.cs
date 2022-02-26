using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Managers;
using UnityEngine;
using UnityEngine.Events;

public class Clock : MonoBehaviour,IInteractable
{
    public CameraManager cameraManager;
    public InputManager inputManager;
    public float rotationSpeed;
    public Transform hourHand;
    public Transform minuteHand;
    public Player player;
    public PlayerClockState clockState;
    public CinemachineVirtualCamera clockCamera;
    public AudioSource windSound;

    [SerializeField] private int selectedHallway = 1;
    [SerializeField] private UnityEvent hallwayChanged;
    private bool rotating = false;

    public void Selected()
    {
        Debug.Log("Selected");
    }

    public void Deselected()
    {
        Debug.Log("Deselected");
    }

    public void Interact()
    {
        clockState.setSelectedClock(this);
        player.switchState(Player.state.clock);
        Debug.Log("Interacted");
    }

    private void Update()
    {
        RotateHourHandToPosition();
    }

    public void RotateHourHandToPosition()
    {
        Vector3 to = new Vector3(0, 0, selectedHallway * 45);
            if (Vector3.Distance(hourHand.eulerAngles, to) > 0.01f)
            {
                hourHand.rotation = Quaternion.Lerp(hourHand.rotation, Quaternion.Euler(0, 0, selectedHallway * 45), 0.5f);
                rotating = true;
            }
            else
            {
                rotating = false;
                hallwayChanged.Invoke();
            }
    }

    public void Next()
    {
        windSound.Play();
        if (selectedHallway + 1 > 7)
        {
            selectedHallway = 0;
        }
        else
        {
            selectedHallway += 1;
        }
    }
    
    public void Previous()
    {
        windSound.Play();
        if (selectedHallway - 1 < 0)
        {
            selectedHallway = 7;
        }
        else
        {
            selectedHallway -= 1;
        }
    }

    public bool IsRotating()
    {
        return rotating;
    }

    public int GetSelectedHallway()
    {
        return selectedHallway;
    }
}
