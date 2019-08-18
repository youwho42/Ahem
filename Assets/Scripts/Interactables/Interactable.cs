using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Interactable : MonoBehaviour
{
    public float interactionRadius = 1.0f;

    bool isFocus = false;
    bool hasInteracted;

    CircleCollider2D circleCollider;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.radius = interactionRadius;
        circleCollider.isTrigger = true;
    }



    public virtual void Interact()
    {
        
    }

    public void OnFocus()
    {
        isFocus = true;
        hasInteracted = false;
    }

    public void OnUnfocus()
    {
        isFocus = false;
        hasInteracted = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
