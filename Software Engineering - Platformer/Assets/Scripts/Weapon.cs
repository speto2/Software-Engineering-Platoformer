using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    public Transform firePoint;
    public GameObject bulletPrefab;
    public bool isPistol;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;

    void Start() {
        isPistol = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && isPistol)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire1") && !isPistol) {
            StartCoroutine(rayCast());
        }
        if (Input.GetButtonDown("Fire2")) {
            isPistol = !isPistol;
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    IEnumerator rayCast() {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hitInfo.point);
        }else{
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        lineRenderer.enabled = true;

        yield return 0;

        lineRenderer.enabled = false;
    }
}
