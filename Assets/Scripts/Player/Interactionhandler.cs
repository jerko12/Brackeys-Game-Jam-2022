using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactionhandler : MonoBehaviour
{
    [SerializeField] LayerMask interactionLayer;
    [SerializeField] float interactionDistance = 2;
    [SerializeField] float interactionRadius = .2f;
    [SerializeField] Camera cam;
    public IInteractable currentInteractable;
    //Vector3 hitPoint = 

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.SphereCast(cam.ScreenPointToRay(new Vector2(Screen.width/2,Screen.height/2)),interactionRadius, out hit, interactionDistance, interactionLayer))
        {
            if(hit.transform.TryGetComponent(out IInteractable _hitInteractable)){
                updateCurrentInteractable(_hitInteractable);
            }
            else
            {
                updateCurrentInteractable(null);
            }
            return;
        }
        else
        {
            updateCurrentInteractable(null);
        }
    }

    public void updateCurrentInteractable(IInteractable interactable)
    {
        if (currentInteractable == interactable) return;

        if(currentInteractable != null) currentInteractable.Deselected();
        currentInteractable = interactable;
        if (currentInteractable != null) currentInteractable.Selected();
    }

    public void InteractWithCurrentInteractable()
    {
        if (currentInteractable == null) return;
        currentInteractable.Interact();
    }
}
