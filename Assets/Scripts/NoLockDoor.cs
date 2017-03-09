using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoLockDoor : MonoBehaviour {

    public bool open = false;

    // Update is called once per frame
    void Update () {
        if (open)
        {
            transform.Translate(new Vector2(0, 0.02f));
        }
    }
}
