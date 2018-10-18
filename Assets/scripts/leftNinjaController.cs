using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftNinjaController : MonoBehaviour {
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
        flip();
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
            firing = false;
            if (seen)
            {
                MyAnimator.SetBool("true", true);
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
            MyAnimator.SetBool("true", false);
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
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Projectile")
        {
            Destroy(coll);
            Destroy(gameObject);
        }
    }
    void idle()
    {
        transform.localScale = new Vector3(.5f, .5f, .5f);
        MyAnimator.Play("idle");
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
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
        MyAnimator.Play("Explosion");
        GetComponent<Collider2D>().enabled = false;
        sprite.enabled = false;

    }
    void flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
