﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thebullet : MonoBehaviour {
    public GameObject theBullet;
    public string lk;

    public int speed = 12;

    void Start() {
        lk = Player.lastkey;
    }

    void Update() {
        transform.Translate(-Time.deltaTime, 0, 0);
        if (lk == "l") {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }
        else if (lk == "r") {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }
        Object.Destroy(gameObject, 10f); //deleted after being around for so long
    }
}