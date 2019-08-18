using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Interactable focus;

    PlayerInput input;

    private void Start()
    {
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (focus != null && input.interactInput)
        {
            focus.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable != null)
        {
            SetFocus(interactable);
            focus.OnFocus();
        }
    }

    

    private void OnTriggerExit2D(Collider2D other)
    {
        if(focus != null)
        {
            focus.OnUnfocus();
        }
        RemoveFocus();
    }

    void SetFocus(Interactable interactable)
    {
        focus = interactable;
    }

    void RemoveFocus()
    {
        focus = null;
    }
}
