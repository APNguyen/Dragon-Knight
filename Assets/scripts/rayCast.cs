using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayCast : MonoBehaviour {

    public float floatHeight;
    public float liftForce;
    public float damping;
    private Rigidbody2D rb2D;
    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right);
        //if (hit.collider != null)
        //{

        //    Debug.Log(hit.collider.tag);
        //}

    }


}
