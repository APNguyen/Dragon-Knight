using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class playerTracker : MonoBehaviour {

    public bool player1Alive;
    public bool player2Alive;
    public int player1Lives;
    public int player2Lives;
    public int restartScene;
    private GameObject[] hpValues;
    //public static playerTracker instance = null;
    
	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        //if (instance == null)
        //    instance = this;
        //else if (instance != this)
        //    Destroy(gameObject); 
    }
	void Start () {
        player1Alive = true;
        player2Alive = true;
        player1Lives = 3;
        player2Lives = 3;
        restartScene = SceneManager.GetActiveScene().buildIndex;
        hpValues = GameObject.FindGameObjectsWithTag("hpValues");
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            hideHP();

        }
        else
            showHP();
        //HPBox.text = "P1 HP: " + player1Lives + '\n' + "P2 HP: " + player2Lives;
    }

    void hideHP()
    {
        foreach (GameObject g in hpValues)
        {
            g.SetActive(false);
        }
    }

    void showHP()
    {
        foreach (GameObject g in hpValues)
        {
            g.SetActive(true);
        }
    }

    public void respawnPlayer1()
    {

    }

    public void respawnPlayer2()
    {

    }
}
