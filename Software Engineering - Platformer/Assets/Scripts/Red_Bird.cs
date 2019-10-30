using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bird : MonoBehaviour {
    public bool facingRight = false;

    public GameObject redBird;

    public int hp = 1;

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

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall") { //death when touching enemy object
            Debug.Log("Flip");
            Flip();
        }
        if (collision.gameObject.tag == "bullet") {
            Debug.Log("enemy death");
            Destroy(redBird);
        }
    }

    void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }
}