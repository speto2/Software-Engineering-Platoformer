using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    float firerate = 3;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPistol;
    //public GameObject impactEffect;
    public LineRenderer lineRenderer;
    private bool facingRight;
    public bool space;
    int damage = 50;
    private float NextFire;

    void Start() {
        isPistol = true;
        facingRight = true;
    }
    void Update() {
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown("f")) && isPistol) {
            Shoot();
        }
        if (((Input.GetButtonDown("Fire1") || Input.GetKeyDown("f")) && !isPistol) && Time.time > NextFire) {
            NextFire = Time.time + firerate;
            StartCoroutine(rayCast());
        }
        if (Input.GetButtonDown("Fire2")) {
            isPistol = !isPistol;
        }
        float movex = Input.GetAxisRaw("Horizontal");
        if (!space) {
            rightLeft(movex);
        }
        else {
            spaceRotate();
        }
    }

    void Shoot() {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator rayCast() {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Enemy enemy = hitInfo.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            //Instantiate(impactEffect);
        }
        else {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return 0;
        yield return 0;
        yield return 0;

        lineRenderer.enabled = false;
    }

    private void rightLeft(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
        }

    }

    void spaceRotate() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
        }
    }
}