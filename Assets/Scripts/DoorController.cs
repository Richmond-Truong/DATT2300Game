using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public bool open = false;
    float howMuchMoved = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(open && howMuchMoved < 2)
        {
            transform.Translate(new Vector2(0, 0.02f));
            howMuchMoved += 0.02f;
        }
	}
}
