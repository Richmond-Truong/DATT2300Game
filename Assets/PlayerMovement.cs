using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rb2d;

    public float speed = 2, acceleration = 2;
    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveH = Input.GetAxis("Horizontal");
        //float moveV = Input.GetAxis("Vertical");
        Vector2 move = new Vector2(moveH,0);
        rb2d.velocity = move * speed * acceleration;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb2d.AddForce(new Vector2(0, 1000));
        }
    }


}
