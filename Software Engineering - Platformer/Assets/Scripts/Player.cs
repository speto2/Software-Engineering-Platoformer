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

    protected Rigidbody2D rb;

    public Transform playerTransform;
    public GameObject player;
    public GameObject startPos;
    public GameObject bulletPrefab;

    public string loadLvl;
    public int lvl = 1;
    public int fireCoolDown = 1; 
    
    public static string lastkey;

    private bool facingRight;
    protected int facing; // 0 - right, 1 - up, 2 - left, 3 - down

    protected void Start() {
        facingRight = true;
        facing = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update() {
        Physics.gravity = new Vector3(0f, -9.81f, 0f);
        float movex = Input.GetAxisRaw("Horizontal");
        float move = movex * pSpeed;
        rb.velocity = new Vector2(move, rb.velocity.y);
        rightLeft(movex);

        if (onGround) {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                jumped++;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.D)) {
                rb.velocity = new Vector2(rb.velocity.x, -jumpSpeed);
                jumped++;
            }
        }

        if (transform.position.y < -10) {
            playerDeath();
        }
    }

    private void rightLeft(float horizontal){
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
            facingRight = !facingRight;

            transform.Rotate(0f, 180f, 0f);
        }
    }

    void fire() { //fire a shot
        if(lastkey == "l") {
            Vector3 spawnPosition = new Vector3(transform.position.x-1, transform.position.y, transform.position.z);
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }else if(lastkey == "r") {
            Vector3 spawnPosition = new Vector3(transform.position.x+1, transform.position.y, transform.position.z);
            Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "enemy") { //death when touching enemy object
            Debug.Log("player death");
            playerDeath();
        }
        if (collision.gameObject.tag == "bullet") {
            backgroundFollow.playerHasDied();
            playerDeath();
        }
        if(collision.gameObject.tag == "endgate") {
            lvl++;
            nextLevel(false); //method that loads next level
        }
        if(collision.gameObject.tag == "planet") {
            onGround = true;
        }
    }

    private void playerDeath() {
        transform.localPosition = new Vector2(startPos.transform.position.x, startPos.transform.position.y);
    }

    void nextLevel(bool canpass) {
        if(canpass) {
            switch(lvl) {
                case 2:
                    SceneManager.LoadScene("Level-02");
                    l("Load level 2");
                break;
                case 3:
                    SceneManager.LoadScene("Level-03");
                    l("Load level 3");
                break;
                case 4:
                    SceneManager.LoadScene("Level-04");
                    l("Load level 4");
                break;
            }
        }
    }

    void OnCollisionStay2D(Collision2D collider) {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider) {
        onGround = false;
    }

    private void CheckIfGrounded() {
        Collider2D[] hits;
        
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.OverlapCircleAll(positionToCheck, 0.05f);
        
        if (hits.Length > 0) {
            onGround = true;
        }
    }
    
    public void l(string log) {
        Debug.Log(log);
    }
}
