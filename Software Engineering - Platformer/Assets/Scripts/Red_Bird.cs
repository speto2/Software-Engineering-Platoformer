using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Bird : MonoBehaviour {
    public float moveSpeed = 5f;
    public int hp = 1;

    

	void Start () {
		
	}
	
	void Update () {
		if(hp >= 0) { //death
            Destroy(this);
        }
	}
}
