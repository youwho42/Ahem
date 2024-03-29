﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : MonoBehaviour, IBehaviorState
{

    DetectPlayer detectPlayer;

    void Start()
    {
        detectPlayer = GetComponent<DetectPlayer>();
        
    }

    public void RunBehavior()
    {
        Debug.Log("Idle Behaviour");
    }

    public bool CheckBehaviorStatus()
    {
        
        return !detectPlayer.CheckForPlayer();
    }

}
