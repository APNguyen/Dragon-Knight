using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class buttonManager : MonoBehaviour {
   
    // Use this for initialization

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

    }

    
    public void StartGame()
    {
        GameObject tracker = GameObject.FindGameObjectWithTag("playerTracker");
        tracker.GetComponent<playerTracker>().restartScene = 2;
        SceneManager.LoadSceneAsync(2);
    }
   
  


 



    public void quit()
    {
        Application.Quit();
    }

    public void restartGame()
    {
        GameObject tracker = GameObject.FindGameObjectWithTag("playerTracker");
        tracker.GetComponent<playerTracker>().player1Lives = 3;
        tracker.GetComponent<playerTracker>().player2Lives = 3;
        tracker.GetComponent<playerTracker>().player1Alive = true;
        tracker.GetComponent<playerTracker>().player2Alive = true;
        int p1Life = tracker.GetComponent<playerTracker>().player1Lives;
        int p2Life = tracker.GetComponent<playerTracker>().player2Lives;
        SceneManager.LoadSceneAsync(tracker.GetComponent<playerTracker>().restartScene);
    }

    public void MainMenu()
    {
        Destroy(GameObject.FindGameObjectWithTag("playerTracker"));
        SceneManager.LoadSceneAsync(0);
    }
}
