using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFood : MonoBehaviour
{
    public LayerMask foodLayer;

    public float detectDistance = 3f;

    public Transform CheckForFood()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, .3f, playerLayer);
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectDistance, foodLayer);
        if(hit != null)
        {
            return hit.transform;
        }
        return null;
    }
}
