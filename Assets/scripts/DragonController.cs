using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class DragonController : MonoBehaviour {
    public float speed = 100.0f;
    public float jumpPower = 10.0f;
    public GameObject fireLocation;
    private Rigidbody2D DragBody;
    private Animator MyAnimator;
    public GameObject projectilePrefab;
    private float fireRate = 0.695f;
    private float nextFire;
    public bool LR = true;
    public bool isGrounded = true;
    private GameObject tracker;
    public RectTransform HpBar1;
    public RectTransform HpBar2;

    //Sound Stuff.
    private AudioSource[] soundSources;

    private bool isShooting;

	// Use this for initialization
	void Start () {
        MyAnimator = GetComponent<Animator>();
        DragBody = GetComponent<Rigidbody2D>();
        GetComponent<Animator>().SetBool("DragRight", false);
        tracker = GameObject.FindGameObjectWithTag("playerTracker");
        HpBar1.sizeDelta = new Vector2(tracker.GetComponent<playerTracker>().player1Lives*33, HpBar1.sizeDelta.y);
        soundSources = gameObject.GetComponentsInChildren<AudioSource>();

	}

    void flip()
    {
        LR = !LR;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void fireProjectile()
    {
        if (Time.time > nextFire)
        {
            Instantiate(projectilePrefab, fireLocation.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (Input.GetKey(KeyCode.A))
        {
            //LR = false;
            if (LR)
                flip();
            transform.position += Vector3.left * speed * Time.deltaTime;
            MyAnimator.SetBool("DragRight", true);
        }
        if (Input.GetKeyUp(KeyCode.A))
            MyAnimator.SetBool("DragRight", false);


        if (Input.GetKey(KeyCode.D))
        {
            //LR = true;
            if (!LR)
                flip();
            transform.position += Vector3.right * speed * Time.deltaTime;
            MyAnimator.SetBool("DragRight", true);
        }
        if (Input.GetKeyUp(KeyCode.D))
            MyAnimator.SetBool("DragRight", false);


        if (Input.GetKey(KeyCode.R))
        {
            MyAnimator.Play("Fire");
            if (!soundSources[1].isPlaying)
                soundSources[1].Play();
            fireProjectile();
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            jump();
        }
        
    }
    void jump()
    {
        if (isGrounded)
        {
            isGrounded = false;
            soundSources[0].Play();
            DragBody.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Debug.Log(coll.collider.tag);
        if (coll.collider.tag == "Ground")
        {
            isGrounded = true;
            DragBody.velocity = new Vector2(DragBody.velocity.x, 0f);
        }
        else if(coll.collider.tag == "Enemy")
        {
            int p1Life = --tracker.GetComponent<playerTracker>().player1Lives;
            HpBar1.sizeDelta = new Vector2(tracker.GetComponent<playerTracker>().player1Lives*33, HpBar1.sizeDelta.y);
            
            if (tracker.GetComponent<playerTracker>().player1Lives <= 0)
            {
                tracker.GetComponent<playerTracker>().player1Alive = false;
                Destroy(gameObject);
                if (tracker.GetComponent<playerTracker>().player2Alive == false)
                    SceneManager.LoadSceneAsync(1);
            }
            
        }
       
        else if(coll.collider.tag == "nextLevel")
        {
            //SceneManager.LoadSceneAsync(0);
            ++tracker.GetComponent<playerTracker>().restartScene;
            if (tracker.GetComponent<playerTracker>().player1Lives == 0)
                ++tracker.GetComponent<playerTracker>().player1Lives;
            if (tracker.GetComponent<playerTracker>().player2Lives == 0)
                ++tracker.GetComponent<playerTracker>().player2Lives;
            tracker.GetComponent<playerTracker>().player1Alive = true;
            tracker.GetComponent<playerTracker>().player2Alive = true;
            SceneManager.LoadSceneAsync(tracker.GetComponent<playerTracker>().restartScene);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemyProjectile")
        {
            int p1Life = --tracker.GetComponent<playerTracker>().player1Lives;
            HpBar1.sizeDelta = new Vector2(tracker.GetComponent<playerTracker>().player1Lives * 33, HpBar1.sizeDelta.y);
            //Destroy(gameObject);
            if (tracker.GetComponent<playerTracker>().player1Lives <= 0)
            {
                tracker.GetComponent<playerTracker>().player1Alive = false;
                Destroy(gameObject);
                if (tracker.GetComponent<playerTracker>().player2Alive == false)
                    SceneManager.LoadSceneAsync(1);
            }
        }
    }
  

}
