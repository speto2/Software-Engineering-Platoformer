using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bird : MonoBehaviour {
    public float moveSpeed = 5f;
    public int hp = 1;

<<<<<<< HEAD
    

	void Start () {
		
	}
=======
    public bool facingRight = false;

    void Start () {

    }
>>>>>>> parent of c374afa... Destroy Fixes
	
	void Update () {
		if(hp >= 0) { //death
            Destroy(this);
        }
	}
<<<<<<< HEAD
=======

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "bullet") { //death when getting hit by bullet
            Debug.Log("test1");
            Destroy(this);
        }
        if (collision.gameObject.tag == "wall") { //turn around when hitting the wall
            Flip();
        }
    }

    public void Flip() { //method to flip sprites x around
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }
>>>>>>> parent of c374afa... Destroy Fixes
}
