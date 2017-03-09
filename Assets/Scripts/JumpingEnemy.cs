using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : Enemy {
    float nextJumpTime;
    float waitTime = 5f;
    // Use this for initialization
    public override void Start () {
        base.Start();
        nextJumpTime = 1;
    }
	
	// Update is called once per frame
	void Update () {

        jump();   
        controller.Move(velocity * Time.deltaTime, new Vector2(0, 0));
        if (controller.collisions.left || controller.collisions.right )
        {
            hitX();
        }
        if (controller.collisions.below || controller.collisions.above)
        {
            hitY();
        }
    }

    void jump()
    {
        if (!controller.collisions.below)
        {
            velocity.y -= gravity * Time.deltaTime;
            
        }
        //print(Time.time);
        if (Time.time > nextJumpTime)
        {
            velocity.y = 10;
            
            nextJumpTime = Time.time + waitTime;
        }
    }

    void hitX()
    {
        
        if (controller.collisions.whatHitX.CompareTag("Player") )
        {
            Destroy(controller.collisions.whatHitX);
            
            
        }
    }
    void hitY()
    {
        if (controller.collisions.whatHitY.CompareTag("Player"))
        {
            Destroy(controller.collisions.whatHitY);
     
        }
        
    }
}
