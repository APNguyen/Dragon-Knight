using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    private Transform player;
    private Transform player2;
    private GameObject tracker;
    void Start()
    {
        tracker = GameObject.Find("playerTracker");
        player = GameObject.Find("Dragon").transform;
        player2 = GameObject.Find("Dragon 1").transform;
    }

    void Update()
    {
        if (tracker.GetComponent<playerTracker>().player1Alive == true)
        {
            Vector3 playerpos = player.position;
            //playerpos.x = transform.position.x;
            //playerpos.y = transform.position.y;
            playerpos.z = transform.position.z;
            transform.position = playerpos;
        }
        else if (tracker.GetComponent<playerTracker>().player1Alive == false && tracker.GetComponent<playerTracker>().player2Alive == true)
        {
            Vector3 playerpos = player2.position;
           // playerpos.x = transform.position.x;
            //playerpos.y = transform.position.y;
            playerpos.z = transform.position.z;
            transform.position = playerpos;
        }
    }
    //public Transform player;

    //// Use this for initialization
    //void Start()
    //{
    //    transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //transform.position += Vector3.left * 2.0f * Time.deltaTime;
    //    //transform.position = player.transform.position.x;
    //    //transform.position = new Vector3(player.position.x, player.position.y, 0);
    //    transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    //}
}
