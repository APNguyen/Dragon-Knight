using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController2 : MonoBehaviour {
    public float maxSpeed = 20f;
    Vector3 pos;
    Vector3 velocity;
    private GameObject player;
    private int LR = 3;
    private bool facingRight;
    void Awake()
    {

    }

    //GameObject persistent = GameObject.FindGameObjectWithTag("Persistent");
    //persistent.GetComponent<persistent>().restartScene = 2;
    //    SceneManager.LoadSceneAsync(0); 
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player2");
        if (player.GetComponent<player2Controller>().LR == true)
        {
            facingRight = true;
            LR = 0;
        }

        else
        {
            facingRight = false;
            LR = 1;
        }
        Invoke("deleteBullet", 3.0f);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.tag != "Player2" && collision.tag != "Player")
        if (collision.tag == "shield")
            Destroy(gameObject);
        else if (collision.tag == "Enemy" || collision.tag == "Wall" || collision.tag == "Cam")
            Destroy(gameObject);
    }
    void deleteBullet()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //Debug.Log(player.GetComponent<DragonController>().LR);
        if (!facingRight)
            flip();
        if (LR == 0)
        {
            transform.position += Vector3.right * maxSpeed * Time.deltaTime;
        }

        else
        {
            transform.position += Vector3.left * maxSpeed * Time.deltaTime;
        }
        //bulletBody.MovePosition(bulletBody.position  * bulletSpeed * Time.deltaTime);
    }
    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
