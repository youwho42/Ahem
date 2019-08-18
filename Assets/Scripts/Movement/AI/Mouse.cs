using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : Entity, IHunger
{

    public float speed;
    Vector2 dir;

    public float foodMeter = 100.0f;


    public enum MiceStates
    {
        Walking,
        Eating,
        Fleeing,
        Hiding,
        Sleeping
    }

    public MiceStates currentState;

    private void Start()
    {
        dir = GetRandomDirection();
    }

    void Update()
    {
        DepleteFood(.01f);
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position, transform.localScale - new Vector3(.01f, .01f, .01f), 0, Vector2.right * dir, .1f);
        switch (currentState)
        {
            case MiceStates.Walking:

                
                if(hit != null)
                {
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.name == gameObject.name || hit[i].collider.CompareTag("WorldObject") || hit[i].collider.CompareTag("Food") && foodMeter >= 75)
                        {
                            continue;
                        }
                        else
                        {
                            dir *= -1;
                        }
                        if (hit[i].collider.CompareTag("Food") && foodMeter <= 75)
                        {
                            
                            currentState = MiceStates.Eating;
                        }
                        
                        
                        
                    }
                    
                }
                Move(dir, speed);

                break;

            case MiceStates.Eating:

                if (hit != null)
                {
                    
                    for (int i = 0; i < hit.Length; i++)
                    {
                        if (hit[i].collider.name == gameObject.name)
                        {
                            continue;
                        }
                        
                            FillFood(hit[i].collider.GetComponent<Entity>().foodValue);
                            Destroy(hit[i].collider.gameObject);
                            currentState = MiceStates.Walking;
                        
                        
                    }

                }


                break;

        }
    }

    Vector2 GetRandomDirection()
    {
        float dir = Mathf.Sign(Random.Range(-1, 1));
        return new Vector2(dir, 0);
    }

    public void DepleteFood(float amountToDeplete)
    {
        foodMeter -= amountToDeplete;
    }

    public void FillFood(float amountToFeed)
    {
        foodMeter += amountToFeed;
    }

    
}
