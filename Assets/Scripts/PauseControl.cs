using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour {
    public GameObject PauseUI;
    bool ispaused = false;
 
	
	
	void Update () {
        if (ispaused)
        {
            Time.timeScale = 0;
        }
        if (!ispaused)
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            pause();
        }

    }

    public void pause()
    {
        ispaused = !ispaused;
        PauseUI.SetActive(ispaused);
    }

    public void mainmenu()
    {
        Application.LoadLevel("titleScene");
        ispaused = !ispaused;
        PauseUI.SetActive(ispaused);
    }
    public void resume()
    {
        ispaused = !ispaused;
        PauseUI.SetActive(ispaused);
    }
}
