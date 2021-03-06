﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : Player {

	GameObject[] planets;
	float distance;
	Collider2D collider;

	// Use this for initialization
	new void Start () {
		base.Start();

		planets = GameObject.FindGameObjectsWithTag("planet");
		distance = int.MaxValue;
		collider = GetComponent<Collider2D>();
		startPos = new GameObject();
		startPos.transform.position = new Vector3(0, 0, 0);
	}

    // Update is called once per frame
    private void playerDeath()
    {
        transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
    }

    new void Update () {
        if (Input.GetKeyDown("r"))
        {
            playerDeath();
        }
        // input
        if (onGround) {
			float moveX = Input.GetAxisRaw("Horizontal");
			float moveY = Input.GetAxisRaw("Vertical");
			if(moveX != 0) {
				transform.rotation = Quaternion.Euler(0, 0, moveX > 0 ? 0 : 180f);
			} else if(moveY != 0) {
				transform.rotation = Quaternion.Euler(0, 0, moveY > 0 ? 90f : 270f);
			}
			rb.velocity = new Vector2(rb.velocity.x + moveX*pSpeed*0.01f, rb.velocity.y + moveY*pSpeed*0.01f);

		} else {
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
				rb.AddForce(new Vector2(0, jumpSpeed/2), ForceMode2D.Impulse);
				facing = 1;
				jumped++;
				transform.rotation = Quaternion.Euler(0,0,90f);
			}
			if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
				rb.AddForce(new Vector2(0, -jumpSpeed/2), ForceMode2D.Impulse);
				facing = 3;
				jumped++;
				transform.rotation = Quaternion.Euler(0,0,270f);
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
				rb.AddForce(new Vector2(-jumpSpeed/2, 0), ForceMode2D.Impulse);
				facing = 2;
				jumped++;
				transform.rotation = Quaternion.Euler(0,0,180f);
			}
			if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
				rb.AddForce(new Vector2(jumpSpeed/2, 0), ForceMode2D.Impulse);
				facing = 0;
				jumped++;
				transform.rotation = Quaternion.Euler(0,0,0);
			}
		}

		if(rb.velocity.magnitude > 10)
			rb.velocity = Vector2.ClampMagnitude(rb.velocity, 10);

        if (transform.position.y < -10) {
            transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        }

		Physics.gravity = new Vector3(0f, 0f, 0f);

		float tempDistance = 0, angle = 0;
		Vector2 normal = new Vector2();

		foreach(GameObject planet in planets) {

			Collider2D planetCollider = planet.GetComponent<Collider2D>();

			tempDistance = Mathf.Abs(planetCollider.Distance(collider).distance);
			if(tempDistance < distance) {
				distance = tempDistance;
				normal = planetCollider.Distance(collider).normal;
			}
		}

		if(!onGround && distance > 0) {
			float force = 0.01f * Mathf.Pow(distance, 2);
			rb.AddForce(force * normal, ForceMode2D.Impulse);
		} else if(onGround) {
			rb.AddForce(-0.4f * rb.velocity); // friction
		}

		distance = int.MaxValue;
	}
}
