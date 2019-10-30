using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  desertEnemy1: MonoBehaviour {
    public bool facingRight = false;

    public GameObject enemy;

    public int hp = 1;

    void Start() {

    }

    void Update() {
        if (hp >= 0) { //death
            if (hp <= 0) { //death
                Destroy(enemy);
            }
        }
        transform.Translate(0, 0, Time.deltaTime);
        if (facingRight) {
            transform.Translate(Time.deltaTime, 0, 0);
        }
        else {
            transform.Translate(-Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall" || collision.gameObject.tag == "enemy") { //death when touching enemy object
            Flip();
        }
        if (collision.gameObject.tag == "bullet") {
            Destroy(enemy);
        }
    }

    void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }
}