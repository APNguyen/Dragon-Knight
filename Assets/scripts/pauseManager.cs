using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseManager : MonoBehaviour {

    private GameObject[] pauseObjects;
    private GameObject[] controlObjects;
    bool control = false;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        pauseObjects = GameObject.FindGameObjectsWithTag("Paused");
        controlObjects = GameObject.FindGameObjectsWithTag("Controls");
        hidePaused();
        HideControlFirst();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
                HideControl();
            }
        }
	}

    void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    void ControlMenu()
    {
       // hidePaused();
       // ShowControl();
    }

    void HideControlFirst()
    {
        foreach (GameObject g in controlObjects)
        {
            g.SetActive(false);
        }
    }
  

   public void ShowControl()
    {
        hidePaused();
        foreach (GameObject g in controlObjects)
        {
          //  Debug.Log("HERE");
            g.SetActive(true);
        }
        control = false;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void pauseControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }
    public void HideControl()
    {
        if (!control)
        {
            control = true;
            foreach (GameObject g in controlObjects)
            {
                g.SetActive(false);
            }
            if (Time.timeScale == 0)
                showPaused();
        }
        
    }
    public void quit()
    {
        Application.Quit();
    }

}
