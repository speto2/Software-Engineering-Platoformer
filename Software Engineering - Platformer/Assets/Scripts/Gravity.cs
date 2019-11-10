using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
	
	GameObject[] planets;
	float distance;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		planets = GameObject.FindGameObjectsWithTag("planet");
		distance = 0;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Physics.gravity = new Vector3(0f, 0f, 0f);

		float tempDistance = 0, angle = 0;
		foreach(GameObject planet in planets) {
			tempDistance = Vector2.Distance(transform.position, planet.transform.position);
			if(tempDistance < distance) {
				distance = tempDistance;
				angle = Mathf.Deg2Rad * Vector2.Angle(transform.position, planet.transform.position);
			}
		}

		if(distance > 0) {
			float force = 0.1f * Mathf.Pow(distance, 2);
			rb.AddForce(new Vector2(force * Mathf.Cos(angle), force * Mathf.Sin(angle)), ForceMode2D.Impulse);
		}
	}
}
