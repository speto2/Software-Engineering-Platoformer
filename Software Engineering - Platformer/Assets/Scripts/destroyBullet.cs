using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBullet : MonoBehaviour {
    public float destroyTime = 15f;
    public GameObject bullet;

	void Start () {
        Destroy(bullet, destroyTime);
	}
}
