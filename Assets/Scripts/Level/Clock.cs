using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
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
    [SerializeField] private UnityEvent<int> hallwayChanged;
    public bool rotating = false;

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

    private void Start()
    {
        cameraManager = CameraManager.Instance;
        inputManager = InputManager.Instance;
        player = PlayerManager.Instance.player;
        clockState = player.clock;

    }

    private void Update()
    {
        RotateHourHandToPosition();
    }

    public void RotateHourHandToPosition()
    {
        //Vector3 to = new Vector3(90, 0, selectedHallway * 45);
        Quaternion goalRotation = Quaternion.Euler(90, 0, selectedHallway * 45);
       // Debug.Log(to + "  " + hourHand.localRotation.eulerAngles);
        //f (Vector3.Distance(hourHand.localRotation.eulerAngles, to) > 0.05f)
            if (Quaternion.Angle(hourHand.localRotation, goalRotation) > 1)
            {
                hourHand.localRotation = Quaternion.Lerp(hourHand.localRotation, goalRotation, rotationSpeed * Time.deltaTime);
                rotating = true;
            }
            else
            {
                rotating = false;
                hallwayChanged.Invoke(selectedHallway);
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
