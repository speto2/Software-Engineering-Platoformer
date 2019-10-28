using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thebullet : MonoBehaviour {
    public int moveSpeed = 5;
    public string lastk;

	void Start () {
		
	}
	
	void Update () {
        lastk = Player.lastkey;
    }
}
