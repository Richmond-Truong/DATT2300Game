using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMainGame : MonoBehaviour {

    void OnMouseDown()
    {
        Application.LoadLevel("scene1");
    }
}
