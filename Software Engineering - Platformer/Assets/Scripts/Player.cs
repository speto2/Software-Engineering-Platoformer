using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    
    public float pSpeed = 5f;
    public float jumpSpeed = 5f;

    public bool alive = true;
    public bool onGround = false;

    public int jumped = 0;

    Rigidbody2D rb;

    public Transform playerTransform;
    public GameObject player;
    public GameObject startPos;
    public GameObject bulletPrefab;

    public string loadLvl;
    public int lvl = 1;

    //public Collider2D objectCollider;
    //public Collider2D anotherCollider;

    public static string lastkey;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * pSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumped++;
            }
        }

        if (player.transform.position.y < -10) {
            player.transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
        }

        /*if (objectCollider.IsTouching(anotherCollider)) {
            Debug.Log("test 1");
            lvl++;
            if (lvl == 2) {
                loadLvl = "GravityTest";
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene("GravityTest");
        }*/

        if(Input.GetKeyDown("f")) { //to fire the shot
            Debug.Log("fire");
            fire();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            lastkey = "r";
            flip();
        }else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
            lastkey = "l";
            flip();
        }
    }

    void flip() {
        if(lastkey == "r") {
            GetComponent<SpriteRenderer>().flipX = true;
        }else {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    void fire() { //fire a shot
        if(lastkey == "l") {
            Vector3 spawnPosition = new Vector3(player.transform.position.x-1, player.transform.position.y, player.transform.position.z);
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }else if(lastkey == "r") {
            Vector3 spawnPosition = new Vector3(player.transform.position.x+1, player.transform.position.y, player.transform.position.z);
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") { //death when touching enemy object
            Debug.Log("player death");
            Destroy(player);
        }
        if (collision.gameObject.tag == "bullet") {
            Destroy(player);
        }
    }

    void OnCollisionStay2D(Collision2D collider) {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider) {
        onGround = false;
    }

    private void CheckIfGrounded() {
        RaycastHit2D[] hits;
        
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);
        
        if (hits.Length > 0) {
            onGround = true;
        }
    }


}
