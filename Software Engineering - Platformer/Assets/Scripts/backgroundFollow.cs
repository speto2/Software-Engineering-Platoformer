using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundFollow : MonoBehaviour {
    public static GameObject bg;
    Camera camera;

    public static float startx, starty;

    public int moveSpeed = 5; 

	void Start () {
        startx = transform.position.x;
        starty = transform.position.y;
        camera = FindObjectOfType<Camera>();
    }
	
	void Update () {
        transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, 0);
    }
    
    public static void playerHasDied() {
        bg.transform.localPosition = new Vector2(startx, starty);
    }
}
