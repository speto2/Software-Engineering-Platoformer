using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
    public GameObject bg;
    Rigidbody2D rb;
    public Transform cam;
    public Vector3 cameraRelative;
    public int moveSpeed = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float multiplier = .01f;
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * moveSpeed * multiplier;
        rb.velocity = new Vector2(move, 0);
        offScreenCheck();
    }

    void offScreenCheck()
    {
        cam = Camera.main.transform;
        Vector3 cameraRelative = cam.InverseTransformPoint(transform.position);
        if (cameraRelative.x > 13)
        {
            transform.localPosition = new Vector2(transform.localPosition.x - 25, transform.localPosition.y);
            // yAxisChange();
            moveSpeed = Random.Range(100, 200);
        }
        else if (cameraRelative.x < -13)
        {
            transform.localPosition = new Vector2(transform.localPosition.x + 25, transform.localPosition.y);
            // yAxisChange();
            moveSpeed = Random.Range(100, 200);
        }
    }

    /*void yAxisChange()
    {
        cam = Camera.main.transform;
        Vector3 cameraRelative = cam.InverseTransformPoint(transform.position);
        bool onScrn = false;
        while (!onScrn)
        {
            float y = Random.Range(cameraRelative.y - 6, 6);
            transform.localPosition = new Vector2(transform.localPosition.x, y);
            if (cameraRelative.y < 6 && cameraRelative.y > -6)
            {
                onScrn = true;
            }
        }
    }*/
    
}
