using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFollow : MonoBehaviour {
    public static GameObject bg;
    Rigidbody2D rb;

    public static float startx, starty;

    public int moveSpeed = 5; 

	void Start () {
        startx = transform.position.x;
        starty = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * moveSpeed;
        rb.velocity = new Vector2(move, 0);
    }
    
    public static void playerHasDied() {
        bg.transform.localPosition = new Vector2(startx, starty);
    }
}
