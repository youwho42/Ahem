using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

	public int foodValue;

    public void Move(Vector2 towardsPos, float speed)
    {
        transform.Translate(towardsPos * speed * Time.deltaTime);
    }



}
