using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float pSpeed = 5f;
    public float jumpSpeed = 5f;

    public bool alive = true;
    public bool onGround = false;

    public int jumped = 0;

    Rigidbody2D rb;

    public Transform playerTransform;
    public GameObject player;
    public GameObject startPos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * pSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);

        if (onGround || jumped <= 2) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumped++;
            }
            if (jumped == 2) {
                jumped = 0;
            }
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            player.transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y); //will need to update to the level start position later
        }

        if (player.transform.position.y < -10) {
            player.transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y); //alsol level start position
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col) {
        if (col.collider.gameObject.tag == "deathBox") {
            transform.position = new Vector2(startPos.transform.position.x, startPos.transform.position.y); //will need to update to the level start position later
        }
    }

    void OnCollisionStay2D(Collision2D collider) {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider) {
        onGround = false;
    }

    private void CheckIfGrounded() {
        RaycastHit2D[] hits;
        
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);
        
        if (hits.Length > 0) {
            onGround = true;
        }
    }
}
