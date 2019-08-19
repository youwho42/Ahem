using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatBehaviour : MonoBehaviour, IBehaviorState
{
    DetectPlayer detectPlayer;
    DetectFood detectFood;

    void Start()
    {
        detectPlayer = GetComponent<DetectPlayer>();
        detectFood = GetComponent<DetectFood>();
    }

    public void RunBehavior()
    {
        Debug.Log("Eating Behaviour");
    }

    public bool CheckBehaviorStatus()
    {
        if(detectFood.CheckForFood() != null && !detectPlayer.CheckForPlayer())
        {
            return true;
        }
        return false;
    }
}
