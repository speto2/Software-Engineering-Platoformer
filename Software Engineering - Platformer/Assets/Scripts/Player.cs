﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    public float pSpeed = 5f;
    public float jumpSpeed = 5f;
    public float distance;
    public float radius;
    public float gravity;

    public bool alive = true;
    public bool onGround = false;
    public bool nearPlanet = false;
    public bool touchingPlanet = false;

    public int jumped = 0;

    Rigidbody2D rb;

    public Transform playerTransform;
    public GameObject player;
    public GameObject startPos;
    public Transform planet;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Physics.gravity = new Vector3(1f, -9.81f, 0f);
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * pSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);

        if (onGround && ! touchingPlanet) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumped++;
            }
        }
        if (touchingPlanet && onGround){
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))
            {
                AwayTarget(planet, distance, gravity);
                jumped++;
            }
        }
        if (nearPlanet)
        {
            FollowTarget(planet, distance, gravity);
        }
            if (Input.GetKeyDown(KeyCode.R)) {
            player.transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y); 
        }
        else { }

        if (player.transform.position.y < -10) {
            player.transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        }
        distance = Vector2.Distance(planet.transform.position, player.transform.position);
        if (distance > radius)
        {
            nearPlanet = false;

        }
        if (radius >= distance)
        {
            nearPlanet = true;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit col) {
        if (col.collider.gameObject.tag == "deathBox") {
            transform.position = new Vector2(startPos.transform.position.x, startPos.transform.position.y); 
        }
    }

    void OnCollisionStay2D(Collision2D collider) {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider) {
        onGround = false;
    }

    void FollowTarget(Transform target, float distanceToStop, float speed)
    {
        var direction = Vector3.zero;
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            direction = target.position - transform.position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        }
    }
    void AwayTarget(Transform target, float distanceToStop, float speed)
    {
        var direction = Vector3.zero;
        if (Vector3.Distance(transform.position, target.position) > distanceToStop)
        {
            direction = transform.position - target.position;
            rb.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
        }
    }

    private void CheckIfGrounded() {
        RaycastHit2D[] hits;
        
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);
        
        if (hits.Length > 0) {
            onGround = true;
            if (nearPlanet)
            {
                touchingPlanet = true;
            }
            else { touchingPlanet = false; }
        }
    }


}
