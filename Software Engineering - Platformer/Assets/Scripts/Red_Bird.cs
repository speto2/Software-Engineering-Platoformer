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
		if(hp >= 0) { //death
            Destroy(this);
        }
        transform.Translate(0, 0, Time.deltaTime);
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "wall") { //death when touching enemy object
            Debug.Log("Flip");
            Flip();
        }
    }

    private void Flip() {
        facingRight = !facingRight;
        GetComponent<SpriteRenderer>().flipX = true;
    }
}
