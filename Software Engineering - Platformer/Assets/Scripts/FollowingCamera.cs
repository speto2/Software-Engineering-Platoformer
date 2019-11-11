using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {       
    public Transform player;
    private Vector3 offset;
    private Vector3 velocity = Vector3.zero;
    public float smoothSpeed = 0.125f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        offset = transform.position - player.transform.position;
    }
    

    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
