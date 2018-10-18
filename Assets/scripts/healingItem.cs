using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healingItem : MonoBehaviour
{

    private GameObject tracker;
    private GameObject player;
    private GameObject player2;
    private RectTransform HpBar1;
    private RectTransform HpBar2;
    // Use this for initialization
    void Start()
    {
        tracker = GameObject.FindGameObjectWithTag("playerTracker");
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        HpBar1 = player.GetComponent<DragonController>().HpBar1;
        HpBar2 = player2.GetComponent<player2Controller>().HpBar2;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag =="Player2")
        {
            Destroy(gameObject);
            if (tracker.GetComponent<playerTracker>().player1Alive && (tracker.GetComponent<playerTracker>().player1Lives < 3))
            {
                ++tracker.GetComponent<playerTracker>().player1Lives;
                HpBar1.sizeDelta = new Vector2(tracker.GetComponent<playerTracker>().player1Lives * 33, HpBar1.sizeDelta.y);
            }
            if (tracker.GetComponent<playerTracker>().player2Alive && (tracker.GetComponent<playerTracker>().player2Lives < 3))
            {
                ++tracker.GetComponent<playerTracker>().player2Lives;
                HpBar2.sizeDelta = new Vector2(tracker.GetComponent<playerTracker>().player2Lives * 33, HpBar2.sizeDelta.y);
            }
        }
    }
}