using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightController : MonoBehaviour {

    public float speed = 5.0f;
    public bool LR = true;
    private Animator MyAnimator;
    private int direction = 1;
    private Rigidbody2D knightBody;
    // Use this for initialization
    void Start () {
        MyAnimator = GetComponent<Animator>();
        knightBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update () {
		if (LR)
        {
            MyAnimator.SetBool("LR", true);
            transform.position += Vector3.right * speed * Time.deltaTime;
          //  direction = 0;
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            //direction = 1;
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "shield")
            return; // do nothing
        else if (collision.tag == "leftWaypoint")
        {
            LR = true;
           // if (direction != 1)
                flip();
        }
        else if (collision.tag == "rightWaypoint")
        {
            LR = false;
           // if(direction != 0)
                flip();
        }
        else if (collision.tag == "Projectile")
        {
            Destroy(collision);
            Destroy(gameObject);
        }
     
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Player2")
        {
            if (LR)
                knightBody.AddForce(Vector3.right * speed, ForceMode2D.Impulse);
            else
                knightBody.AddForce(Vector2.right * 10, ForceMode2D.Impulse);
        }
    }
   

    void flip ()
    {
        LR = !LR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
