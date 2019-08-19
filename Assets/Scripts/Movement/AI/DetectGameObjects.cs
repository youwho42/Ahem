using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGameObjects : MonoBehaviour
{
    public bool FindObject(Transform transform, float radius)
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radius);
        return hit;
    }
}
