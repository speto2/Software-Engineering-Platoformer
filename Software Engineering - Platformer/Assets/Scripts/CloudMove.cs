using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMove : MonoBehaviour {
    public GameObject bg;
    Rigidbody2D rb;

    public int speed = 5;
    private float minXValueWorld;
    private float maxXValueWorld;

    void Start()
    {
        minXValueWorld = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        maxXValueWorld = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    void OffscreenCheck()
    {

        Vector3 screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 maxWorldXWithPlayerSize = Camera.main.WorldToScreenPoint(new Vector3(maxXValueWorld, 0, 0));
        Vector3 minWorldWithPlayerSize = Camera.main.WorldToScreenPoint(new Vector3(minXValueWorld, 0, 0));

        if (screenPos.x < minWorldWithPlayerSize.x)
        {
            this.transform.position = new Vector3(maxWorldXWithPlayerSize.x, this.transform.position.y, this.transform.position.z);
        }

        if (screenPos.x > maxWorldXWithPlayerSize.x)
        {
            this.transform.position = new Vector3(minWorldWithPlayerSize.x, this.transform.position.y, this.transform.position.z);
        }
        screenPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector3 maxWorldWithPlayerSize = new Vector3(maxXValueWorld/ 2, 0, 0);
        minWorldWithPlayerSize = new Vector3(minXValueWorld/ 2, 0, 0);
        Vector3 maxScreenWithPlayerSize = Camera.main.WorldToScreenPoint(maxWorldWithPlayerSize);
        Vector3 minScreenWithPlayerSize = Camera.main.WorldToScreenPoint(minWorldWithPlayerSize);

        if (screenPos.x < minScreenWithPlayerSize.x)
        {
            this.transform.position = new Vector3(
                maxWorldWithPlayerSize.x,
                this.transform.position.y,
                this.transform.position.z);
        }

        if (screenPos.x > maxScreenWithPlayerSize.x)
        {
            this.transform.position = new Vector3(
                minWorldWithPlayerSize.x,
                this.transform.position.y,
                this.transform.position.z);
        }



    }

    void update()
    {
        OffscreenCheck();

    }
}
