using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelStartText : MonoBehaviour {
    public float time = 5; //Seconds to read the text

    void Start()
    {
        Destroy(gameObject, time);
    }
}
