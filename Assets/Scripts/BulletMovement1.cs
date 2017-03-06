using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class BulletMovement1 : MonoBehaviour
{
    float moveSpeed = 20f;
    Controller2D controller;
    Vector2 velocity;
    // Use this for initialization
    int whichway;
    void Start () {
       whichway = Camera.main.GetComponent<CameraFollow>().player.GetComponent<Controller2D>().collisions.faceDir;
       controller = GetComponent<Controller2D>();
    }
	
	// Update is called once per frame
	void Update()
    {
        velocity.y = 0;
        velocity.x = moveSpeed * whichway;
   
        // print(controller.collisions.below);
        controller.Move(velocity * Time.deltaTime, new Vector2(1, 1));


        if (controller.collisions.left || controller.collisions.right || controller.collisions.below || controller.collisions.above)
        {
            hit();
            Destroy(this.gameObject);
        }
    }

    void hit()
    {
        if (controller.collisions.whatHitX.CompareTag("Enemy"))
        {
            Destroy(controller.collisions.whatHitX);
        }
    }
    
}
