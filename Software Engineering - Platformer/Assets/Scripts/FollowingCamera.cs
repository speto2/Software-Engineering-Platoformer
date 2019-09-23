using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour {
    public Transform player;
    public Vector3 offset;

    void Start() {
        Debug.Log("!Camera Follow!");
    }

    void Update() {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
