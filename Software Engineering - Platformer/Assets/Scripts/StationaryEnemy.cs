using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationaryEnemy  : MonoBehaviour { 

    public GameObject obj;

    public int hp = 10;

    void Start()
    {

    }

    void Update()
    {
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
    void Flip()
    { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}