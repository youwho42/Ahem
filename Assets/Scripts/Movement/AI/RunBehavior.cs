using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBehavior : StateMachineBehaviour
{
    Vector2 dir;
    public LayerMask walls;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GetDirection();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        RaycastHit2D hit = Physics2D.Raycast(animator.transform.position, dir, .3f, walls);
        if (hit)
        {
            dir *= -1;
        }

        animator.transform.Translate(dir * 3 * Time.deltaTime);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    void GetDirection()
    {
        dir = new Vector2(Mathf.Sign(Random.Range(-1, 1)), 0);
    }

}
