using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject theBullet;
    public string lk;

    void Start () {
        
    }
	
	void Update () {
        transform.Translate(-Time.deltaTime, 0, 0);
        Object.Destroy(gameObject, 10f); //deleted after being around for so long
    }   
}
