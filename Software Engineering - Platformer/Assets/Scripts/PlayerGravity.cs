using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : Player {

	GameObject[] planets;
	float distance;

	// Use this for initialization
	new void Start () {
		base.Start();

		planets = GameObject.FindGameObjectsWithTag("planet");
		distance = int.MaxValue;
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();

		Physics.gravity = new Vector3(0f, 0f, 0f);

		float tempDistance = 0, angle = 0;
		Vector2 normal = new Vector2();

		foreach(GameObject planet in planets) {
			tempDistance = Vector2.Distance(transform.position, planet.transform.position);
			if(tempDistance < distance) {
				distance = tempDistance;
				angle = Mathf.Deg2Rad * Vector2.Angle(transform.position, planet.transform.position);
				normal = (planet.transform.position - transform.position).normalized;
			}
		}

		print(angle + ", " + distance);

		if(!onGround && distance > 0) {
			float force = 1f / Mathf.Pow(distance, 2);
			rb.AddForce(Vector2.Scale(new Vector2(force, force), normal), ForceMode2D.Impulse);
		}

		distance = int.MaxValue;
	}
}
