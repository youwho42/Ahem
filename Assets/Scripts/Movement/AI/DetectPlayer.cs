using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{

    public LayerMask playerLayer;

    public float detectDistance = .3f;
    
    public bool CheckForPlayer()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, .3f, playerLayer);
        Collider2D hit = Physics2D.OverlapCircle(transform.position, detectDistance, playerLayer);
        return hit;
    }
}
