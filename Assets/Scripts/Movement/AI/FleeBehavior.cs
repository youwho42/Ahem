using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeBehavior : MonoBehaviour, IBehaviorState
{

    DetectPlayer detectPlayer;

    void Start()
    {
        detectPlayer = GetComponent<DetectPlayer>();
        
    }

    public void RunBehavior()
    {
        Debug.Log("Flee Behaviour");
    }

    public bool CheckBehaviorStatus()
    {
        return detectPlayer.CheckForPlayer();
    }

}
