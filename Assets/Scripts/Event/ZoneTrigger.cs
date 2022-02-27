using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ZoneTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter;
    public UnityEvent onPlayerExit;

    private void OnTriggerEnter(Collider other)
    {
        onPlayerEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        onPlayerExit?.Invoke();
    }
}
