using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool canPickUp;
    public AudioSource pickupSound;
    public GameObject model;
    public KeyManager keyManager;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");
        if (other.gameObject.tag == "Player" && canPickUp)
        {
            pickupSound.Play();
            canPickUp = false;
            model.GetComponent<Renderer>().enabled = false;
            keyManager.PickedUpKey();
        }
    }
}
