using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public float moveSpeed = 6.0f;
    public float wallMoveSpeed = 2.0f;
    public float runSpeed = 10.0f;
    public float crouchSpeed = 1.0f;
    public float maxJumpHeight = 4.0f;
    public float minJumpHeight = 1.0f;
    public float timeToJumpApex = 0.4f;
    [Range(0.0f, 1.0f)]
    public float accelerationAir = 0.2f;
    [Range(0.0f, 1.0f)]
    public float accelerationGround = 0.1f;

    public Vector2 wallJumpUp;
    public Vector2 wallJumpOff;
    public Vector2 wallLeapOff;

    public float maxWallSlideSpeed = 3.0f;
    public float wallStickTime = 0.25f;
    float timeToWallUnstick;

    int wallDirectionX;
    public bool wallSliding;
    public bool isCrouching;
    public bool isRunning;

    float gravity;
    Vector2 velocity;
    float maxJumpVeloctity;
    float minJumpVelocity;
    float velocitySmoothing;

    Controller2D controller;
    PlayerInput input;

    private void Start()
    {
        controller = GetComponent<Controller2D>();
        input = GetComponent<PlayerInput>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVeloctity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    }

    private void Update()
    {
        if (input.isCrouching)
        {
            isCrouching = !isCrouching;
            isRunning = false;
            controller.ChangeCollider(isCrouching);
        }
        if (input.isRunning)
        {
            isRunning = !isRunning;
            isCrouching = false;
        }
        CalculateVelocity();
        HandleWallSliding();

        if(input.jumpInput)
        {
            JumpInputDown();
            
        }
        if(input.jumpInputOver)
        {
            JumpInputUp();
            
        }
        if(input.directionalInput.x == 0)
        {
            isRunning = false;
        }

        controller.Move(velocity * Time.deltaTime, input.directionalInput);

        if (controller.collisions.above || controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
            }
            else
            {
                velocity.y = 0;
            }
            
        }

    }

    void JumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirectionX == input.directionalInput.x)
            {
                velocity.x = -wallDirectionX * wallJumpUp.x;
                velocity.y = wallJumpUp.y;
               
            }
            else if (input.directionalInput.x == 0)
            {
                velocity.x = -wallDirectionX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirectionX * wallLeapOff.x;
                velocity.y = wallLeapOff.y;
            }
        }
        if (controller.collisions.below)
        {
            if (controller.collisions.slidingDownMaxSlope)
            {
                if(input.directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                {
                    velocity.y = maxJumpVeloctity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVeloctity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVeloctity;
            }
            
        }
    }

    void JumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    void HandleWallSliding()
    {
        wallDirectionX = (controller.collisions.left) ? -1 : 1;

        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;
            if (velocity.y < -maxWallSlideSpeed)
            {
                velocity.y = -maxWallSlideSpeed;
            }
            if (input.directionalInput.y != 0)
            {
                velocity.y = wallMoveSpeed * input.directionalInput.y;
            }
            if (timeToWallUnstick > 0)
            {
                velocitySmoothing = 0;
                velocity.x = 0;
                if (input.directionalInput.x != wallDirectionX && input.directionalInput.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }
    }

    void CalculateVelocity()
    {
        float targetVelocity;
        if (isCrouching)
        {
            targetVelocity = input.directionalInput.x * crouchSpeed;
        }
        else if (isRunning)
        {
            targetVelocity = input.directionalInput.x * runSpeed;
        }
        else
        {
            targetVelocity = input.directionalInput.x * moveSpeed;
        }
        //targetVelocity = isCrouching? input.directionalInput.x * crouchSpeed : input.directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocity, ref velocitySmoothing, (controller.collisions.below) ? accelerationGround : accelerationAir);
        velocity.y += gravity * Time.deltaTime;
    }

}
