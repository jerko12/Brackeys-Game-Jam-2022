using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyManager : MonoBehaviour
{
    public bool hasKey;
    [SerializeField] private UnityEvent<bool> keyPickedUp;

    public void PickedUpKey()
    {
        hasKey = true;
        keyPickedUp.Invoke(true);
    }
}
