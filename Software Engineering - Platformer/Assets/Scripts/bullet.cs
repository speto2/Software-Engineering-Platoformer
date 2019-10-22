using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public GameObject theBullet;
    public string lk;

    public int speed = 10;

    void Start () {
        lk = Player.lastkey;
    }
	
	void Update () {
        if(lk == "l") {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
        else if(lk == "r") {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        Object.Destroy(gameObject, 10f); //deleted after being around for so long
    }   
}
