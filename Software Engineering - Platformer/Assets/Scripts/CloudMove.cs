using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
    public GameObject bg;
    Rigidbody2D rb;
    public Transform cam;
    public Vector3 cameraRelative;
    public int moveSpeed = 0;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = Random.Range(100, 200);
    }

    void Update() {
        float multiplier = .01f;
        float movex = -1;
        float move = movex * moveSpeed * multiplier;
        rb.velocity = new Vector2(move, 0);
        offScreenCheck();
    }

    void offScreenCheck()  {
        cam = Camera.main.transform;
        Vector3 cameraRelative = cam.InverseTransformPoint(transform.position);
        if (cameraRelative.x > 13){
            transform.localPosition = new Vector2(transform.localPosition.x - 26, transform.localPosition.y);
            //yAxisChange();
            moveSpeed = Random.Range(100, 200);
        }
        else if (cameraRelative.x < -13) {
            transform.localPosition = new Vector2(transform.localPosition.x + 26, transform.localPosition.y);
           // yAxisChange();
            moveSpeed = Random.Range(100, 200);
        }
        /*if (cameraRelative.y > 5) {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - 5);
            moveSpeed = Random.Range(100, 200);
        }
        else if (cameraRelative.y < 5) {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + 5);
            moveSpeed = Random.Range(100, 200);
        }*/
    }

    void yAxisChange() {
        cam = Camera.main.transform;
        Vector3 cameraRelative = cam.InverseTransformPoint(transform.position);
        bool onScrn = false;
        while (!onScrn) {
            float y = Random.Range (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            transform.localPosition = new Vector2(transform.localPosition.x, y);
        }
    }
    
}
