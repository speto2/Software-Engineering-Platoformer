using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thebullet : MonoBehaviour {

    public float speed = 20f;
    public int damage = 2;
    public Rigidbody2D rb;
    //public GameObject impactEffect;
    public float stop = 0f;

    void Start (){
        rb.velocity = transform.right * speed;
    }

    void Update() {
        if(Mathf.Abs(transform.position.x) > 1000 || Mathf.Abs(transform.position.y) > 1000)
            Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other){
        rb.velocity = transform.right * stop;
        //Instantiate(impactEffect, transform.position, transform.rotation);
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null){
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}