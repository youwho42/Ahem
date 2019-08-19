using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorStateSystem : MonoBehaviour
{
    private List<IBehaviorState> behaviorStates = new List<IBehaviorState>();

    private void Start()
    {
        behaviorStates = GetComponents<IBehaviorState>().ToList();

       
    }

    private void Update()
    {
        foreach (var behavior in behaviorStates)
        {
            if (!behavior.CheckBehaviorStatus())
            {
                continue;
            }
            
            behavior.RunBehavior();
            
        }
    }
}
