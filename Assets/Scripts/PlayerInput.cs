﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{

    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        player.SetDirectionalInput(directionalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.OnJumpInputDown();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.OnJumpInputUp();
        }
        if (Input.GetKey(KeyCode.S))
        {
            player.Shooting();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            player.use();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.LoadLevel("scene2");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            Application.LoadLevel("scene1");
        }
        

    }
}