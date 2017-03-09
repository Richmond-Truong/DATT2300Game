using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWallX : MonoBehaviour {

    public GameObject walls;
    float moveDownAmount = 7.66f;
    public float createAmount;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < createAmount; i++)
        {

            Instantiate(walls, new Vector2(this.transform.position.x + moveDownAmount * i, this.transform.position.y ), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
    }

}
