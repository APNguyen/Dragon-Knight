using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leftSword : MonoBehaviour {
    //public GameObject playerBody;
    private GameObject playerLocation;
    private Vector3 lastPlayerLocation;
    public float bulletSpeed;
    private Rigidbody bulletBody;

    // Use this for initialization
    void Start()
    {
        bulletBody = GetComponent<Rigidbody>();
        Invoke("deleteBullet", 1.0f);
        transform.rotation = Quaternion.Euler(0, 0, 90);

        //playerLocation = new Vector3(playerBody.transform.position.x, playerBody.transform.position.y + 1, playerBody.transform.position.z);
        //transform.rotation = Quaternion.LookRotation(playerPos);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground" || other.gameObject.tag == "Player" || other.gameObject.tag == "Player2")
            deleteBullet();

    }
    private void deleteBullet()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        // lastPlayerLocation = playerLocation;

        //transform.position = Vector3.MoveTowards(transform.position, lastPlayerLocation, bulletSpeed * Time.deltaTime);
        transform.position += Vector3.left * bulletSpeed * Time.deltaTime;
        //bulletBody.MovePosition(bulletBody.position + transform.right * bulletSpeed * Time.deltaTime);
        //transform.rotation = playerBody.transform.rotation;
        //transform.position = playerBody.transform.position;

    }
}
