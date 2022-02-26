using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController controller;
    public Interactionhandler interactionhandler;

    public GameObject camPosition;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        interactionhandler = GetComponent<Interactionhandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
