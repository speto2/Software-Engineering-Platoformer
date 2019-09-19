﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float pSpeed = 5f;
    public float jumpSpeed = 5f;

    public bool alive = true;
    public bool onGround = false;

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

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
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

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0) {
            onGround = true;
        }
    }
}
