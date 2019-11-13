using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class destroy : MonoBehaviour {
    public int time = 20;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, time);
	}
}
