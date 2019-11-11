using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thebullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    void Start (){
        rb.velocity = transform.right * speed;
    }

    void Update() {
        if(Mathf.Abs(transform.position.x) > 100 || Mathf.Abs(transform.position.y) > 100)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Debug.Log("i got here");
        Destroy(gameObject);
    }
}