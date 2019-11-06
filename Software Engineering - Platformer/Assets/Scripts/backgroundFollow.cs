using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFollow : MonoBehaviour {
    public GameObject bg;
    Rigidbody2D rb;

    public int moveSpeed = 5; 

	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * moveSpeed;
        rb.velocity = new Vector2(move, 0);
    }
}
