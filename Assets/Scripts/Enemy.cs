using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Controller2D))]
public class Enemy : MonoBehaviour {
    [HideInInspector]
    public Controller2D controller;
    [HideInInspector]
    public Vector2 velocity;

    public float gravity;
    // Use this for initialization
    public virtual void Start () {
        controller = GetComponent<Controller2D>();
        gravity = 10;
    }
	


	// Update is called once per frame

}
