using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPistol;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public GameObject leavingBullet;
    private bool facingRight;
    public bool space;

    void Start() {
        isPistol = true;
        facingRight = true;
    }
    void Update() {
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown("f")) && isPistol) {
            Shoot();
        }
        if ((Input.GetButtonDown("Fire1") || Input.GetKeyDown("f")) && !isPistol) {
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
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            Instantiate(leavingBullet, hitInfo.point, leavingBullet.transform.rotation);
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

            leavingBullet.transform.Rotate(0f, 180f, 0f);
        }

    }

    void spaceRotate() {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) {
            leavingBullet.transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            leavingBullet.transform.rotation = Quaternion.Euler(0, 0, 270f);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) {
            leavingBullet.transform.rotation = Quaternion.Euler(0, 0, 180f);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) {
            leavingBullet.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}