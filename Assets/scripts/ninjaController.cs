using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ninjaController : MonoBehaviour {
    public Transform startingPosition;
    public Transform endSight;
    public GameObject fireLocation;

    public bool see = false;
    public const string LAYER_NAME = "TopLayer";
    public int sortingOrder = 0;
    public GameObject sword;
    private SpriteRenderer sprite;
    private Animator MyAnimator;
    private int i = 0;
    private bool playAnim = true;
    private bool seen = false;
    private bool firing = false;


    // Use this for initialization
    void Start()
    {
        MyAnimator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(.6f, .6f, .6f);
        hide();
        //sprite.enabled = false;
        //InvokeRepeating("fireProjectile", 0f, 1f);

    }

    // Update is called once per frame
    void Update()
    {
        see = Physics2D.Linecast(startingPosition.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));
        Debug.DrawLine(startingPosition.position, endSight.position, Color.cyan);
        if (!see)
        {
            CancelInvoke();
            if (seen)
            {
                MyAnimator.Play("Explosion");
                seen = false;
            }
            playAnim = true;
            //CancelInvoke();
            hide();
            //Invoke("hide", 1.5f);//hide();
            //MyAnimator.SetBool("true", true);
        }
        else if (see)
        {
            seen = true;
            if (playAnim)
            {
                MyAnimator.Play("Explosion");
                playAnim = false;
            }
            //MyAnimator.SetBool("true", false);
            //CancelInvoke();
            show();
            startFiring();
        }
        // fireProjectile();
    }

    void startFiring()
    {
        if (!firing)
        {
            firing = true;
            InvokeRepeating("fireProjectile", 0.5f, 1f);
        }
    }

    void fireProjectile()
    {
        if (see)
        {
            MyAnimator.Play("NinAtk");
            //MyAnimator.SetBool("atk", false);
            Instantiate(sword, transform.position, transform.rotation);
        }
    }

    void show()
    {
        GetComponent<Collider2D>().enabled = true;
        sprite.enabled = true;
    }

    void hide()
    {
        GetComponent<Collider2D>().enabled = false;
        sprite.enabled = false;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Projectile")
        {
            Destroy(collision);
            Destroy(gameObject);
        }
    }

        //   public Transform startingPosition;
        //   public Transform endSight;
        //   public GameObject fireLocation;

        //   public bool see = false;
        //   public const string LAYER_NAME = "TopLayer";
        //   public int sortingOrder = 0;
        //   public GameObject sword;
        //   private SpriteRenderer sprite;
        //   private Animator MyAnimator;
        //   private int i = 0;
        //   private bool playAnim = true;


        //// Use this for initialization
        //void Start () {
        //       MyAnimator = GetComponent<Animator>();
        //       sprite = GetComponent<SpriteRenderer>();
        //       sprite.enabled = false;
        //       InvokeRepeating("fireProjectile", 0f, 1f);

        //   }

        //   // Update is called once per frame
        //   void Update () {
        //       see = Physics2D.Linecast(startingPosition.position, endSight.position, 1 << LayerMask.NameToLayer("Player"));
        //       Debug.DrawLine(startingPosition.position, endSight.position, Color.cyan);

        //       if (!see)
        //       {
        //           MyAnimator.Play("Explosion");
        //           playAnim = true;
        //           hide();
        //           //MyAnimator.SetBool("true", true);
        //       }
        //       else if (see)
        //       {
        //           if (playAnim)
        //           {
        //               MyAnimator.Play("Explosion");
        //               playAnim = false;
        //           }
        //           //MyAnimator.SetBool("true", false);
        //           show();
        //       }
        //      // fireProjectile();
        //   }

        //   void fireProjectile()
        //   {
        //       if (see)
        //           Instantiate(sword, transform.position, transform.rotation);
        //   }

        //   void show()
        //   {
        //       sprite.enabled = true;
        //   }

        //   void hide()
        //   {

        //       sprite.enabled = false;

        //   }



    }
