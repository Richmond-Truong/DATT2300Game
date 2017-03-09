using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{

    float nextshoot = 0;
    float waitTime = 0.5f;

    public GameObject Bullet;

    int key = 0;

    private int numJump;
    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    Controller2D controller;



    Vector2 directionalInput;
    bool wallSliding;
    int wallDirX;

    void Start()
    {
        
       
        controller = GetComponent<Controller2D>();
        numJump = 2;
        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
    
    }

    void Update()
    {
        
        CalculateVelocity();
        HandleWallSliding();

        controller.Move(velocity * Time.deltaTime, directionalInput);

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

            if (controller.collisions.whatHitY.CompareTag("Bounds"))
            {
                Destroy(this.gameObject);
            }
        }
        if (controller.collisions.right || controller.collisions.left)
        {
            if(controller.collisions.whatHitX.CompareTag("Bounds"))
            {
                Destroy(this.gameObject);
            }
        }

        if (controller.collisions.below)
        {
            numJump = 2;
        }
    }

    public void SetDirectionalInput(Vector2 input)
    {
        directionalInput = input;
    }

    public void OnJumpInputDown()
    {
        if (wallSliding)
        {
            if (wallDirX == directionalInput.x)
            {
                velocity.x = -wallDirX * wallJumpClimb.x;
                velocity.y = wallJumpClimb.y;
            }
            else if (directionalInput.x == 0)
            {
                velocity.x = -wallDirX * wallJumpOff.x;
                velocity.y = wallJumpOff.y;
            }
            else
            {
                velocity.x = -wallDirX * wallLeap.x;
                velocity.y = wallLeap.y;
            }
        }
        if (numJump > 0)
        {
            numJump--;
            if (controller.collisions.slidingDownMaxSlope)
            {
                if (directionalInput.x != -Mathf.Sign(controller.collisions.slopeNormal.x))
                { // not jumping against max slope
                    velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
                    velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
                }
            }
            else
            {
                velocity.y = maxJumpVelocity;
            }
            
        }
    }

    public void OnJumpInputUp()
    {
        if (velocity.y > minJumpVelocity)
        {
            velocity.y = minJumpVelocity;
        }
    }

    public void Shooting()
    {
        if (Time.time > nextshoot)
        {
            nextshoot = Time.time + waitTime;
            if (controller.collisions.faceDir == 1)
            {
                Instantiate(Bullet, new Vector2(this.transform.position.x + .5f, this.transform.position.y), Quaternion.identity);
            }
            else
            {
                Instantiate(Bullet, new Vector2(this.transform.position.x - .5f, this.transform.position.y), Quaternion.identity);
            }
        }
    }


    void HandleWallSliding()
    {
        wallDirX = (controller.collisions.left) ? -1 : 1;
        wallSliding = false;
        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
        {
            wallSliding = true;

            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;

                if (directionalInput.x != wallDirX && directionalInput.x != 0)
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


    public void use()
    {
        if(controller.collisions.left || controller.collisions.right)
        {
            if (controller.collisions.whatHitX.CompareTag("Door"))
            {
                if (key > 0)
                {
                    controller.collisions.whatHitX.GetComponent<DoorController>().open = true;
                }
            }
            if (controller.collisions.whatHitX.CompareTag("NoLockDoor"))
            {
               
                    controller.collisions.whatHitX.GetComponent<NoLockDoor>().open = true;
                
            }
            if (controller.collisions.whatHitX.CompareTag("Key"))
            {
                key++;
                Destroy(controller.collisions.whatHitX);
            }
            if (controller.collisions.whatHitX.CompareTag("Mupgrade"))
            {
                waitTime = 0.2f;
                Destroy(controller.collisions.whatHitX);
            }
        }
    }

    void CalculateVelocity()
    {
        float targetVelocityX = directionalInput.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        velocity.y += gravity * Time.deltaTime;
    }

   
}