using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float pSpeed = 5f;
    public float jumpSpeed = 5f;

    public bool alive = true;
    public bool onGround = true;

    public Transform groundedChecker;
    public float checkGroundR;
    public LayerMask layer_ground;

    Rigidbody2D rb;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * pSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);

        checkForGround();

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
        }
    }

    void checkForGround() {
        Collider2D collider = Physics2D.OverlapCircle(groundedChecker.position, checkGroundR, layer_ground);
        if (groundedChecker != null) {
            onGround = true;
        }
        else {
            onGround = false;
        }
    }
}
