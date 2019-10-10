using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bird : MonoBehaviour {
    public float moveSpeed = 5f;
    public int hp = 1;

    public bool facingRight = false;

    void Start () {

    }
	
	void Update () {
		if(hp <= 0) { //death
            Destroy(this);
        }

        if(facingRight) {
            transform.Translate(Time.deltaTime, 0, 0);
        }else {
            transform.Translate(-Time.deltaTime, 0, 0);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall") { //turn around when hitting the wall
            Flip();
        }
    }

    private void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }
}
