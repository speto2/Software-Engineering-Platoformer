using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bird : MonoBehaviour {
    public bool facingRight = false;

    public GameObject redBird;

    public int hp = 10;

    public int hits = 0;

    void Start() {

    }

    void Update() {
        if (hp >= 0) { //death
            if (hp <= 0) { //death
                Destroy(redBird);
            }
        }
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
        if (other.gameObject.CompareTag("bullet"))
        {
            hits++;
        }
        if (other.gameObject.CompareTag("bigbullet"))
        {
            hits += 5;
        }
        if (hits >= hp)
        {
            Destroy(redBird);
        }
    }
    void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }


}