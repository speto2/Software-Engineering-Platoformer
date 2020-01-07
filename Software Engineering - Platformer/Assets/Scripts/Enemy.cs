using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public bool facingRight = false;

    public GameObject redBird;

    public int hp = 10;

    void Start() {

    }

    void Update() {
        transform.Translate(0, 0, Time.deltaTime);
        if (facingRight) {
            transform.Translate(Time.deltaTime, 0, 0);
        }else {
            transform.Translate(-Time.deltaTime, 0, 0);
        }
    }

    void OnTriggerEnter(Collision2D collision, Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        { //death when touching enemy object
            Debug.Log("Flip");
            Flip();
        }
        if (other.gameObject.CompareTag("enemy"))
        {
            Flip();
        }
    }
    void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }

    public void TakeDamage (int damage) {
        hp -= damage;

        if (hp <= 0){
            Die();
        }
    }

    void Die(){
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}