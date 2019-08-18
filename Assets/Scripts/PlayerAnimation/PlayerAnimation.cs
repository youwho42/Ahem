using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;

    Controller2D controller;

    Transform characterObject;

    Player player;

    PlayerInput input;

    float lastPositionX;
    bool moving;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
        player = GetComponent<Player>();
        anim = GetComponentInChildren<Animator>();
        characterObject = anim.GetComponent<Transform>();
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        float currentPositionX = transform.position.x;

        moving = Mathf.Abs(lastPositionX - currentPositionX) > 0.001f;

        anim.SetBool("IsCrouching", player.isCrouching);
        anim.SetBool("IsRunning", player.isRunning);

        anim.SetFloat("VelocityX", moving ? 1:0);

        anim.SetFloat("InputX", input.directionalInput.x != 0? Mathf.Abs(input.directionalInput.x):1);
        
        anim.SetBool("IsGrounded", controller.collisions.below);

        anim.SetBool("WallSliding", player.wallSliding);

        if (!controller.collisions.below)
        {
            anim.SetFloat("VelocityY", controller.collisions.velocityOld.y * 100);
        }
        
        Flip();

        lastPositionX = currentPositionX;
    }

    void Flip()
    {
        int faceDirection = controller.collisions.faceDirection;
        Vector3 theScale = characterObject.localScale;
        theScale.x = faceDirection;
        characterObject.localScale = theScale;
    }
}
