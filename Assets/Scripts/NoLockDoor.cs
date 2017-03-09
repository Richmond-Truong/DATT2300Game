using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLockDoor : MonoBehaviour {

    public bool open = false;
    float moveAmount;
    // Update is called once per frame
    void Update () {
        if (open && moveAmount < 10)
        {
            transform.Translate(new Vector2(0, 0.02f));
            moveAmount += 0.05f;
        }
    }
}
