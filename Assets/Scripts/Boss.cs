using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {
    int dir = 1;
    int health = 100;
	// Use this for initialization
	void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        velocity.x = 5 * dir;
        controller.Move(velocity * Time.deltaTime, new Vector2(0, 0));
        if (controller.collisions.left || controller.collisions.right)
        {
            dir *= -1;
        }
	}
   public void loseHealth()
    {
        health--;
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
        print(health);
    }
}
