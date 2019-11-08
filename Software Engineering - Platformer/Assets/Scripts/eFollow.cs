using UnityEngine;
using System.Collections;

public class efollow : MonoBehaviour
{
    public Transform target;
    public Transform mytransform;
    public GameObject enemy;
    public float elife = 100f;
    GameObject ebullet;

    // Use this for initialization
    void Start()
    {
        ebullet = Resources.Load("bullets") as GameObject;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);

        GameObject bullets = Instantiate(ebullet) as GameObject;
        bullets.transform.position = transform.position * 1;

        Rigidbody rb = bullets.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * 20;
        Destroy(bullets, 9f);

        if (elife <= 0)
        {
            enemy.SetActive(false);
        }



    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bulleter"))
        {
            //  other.gameObject.SetActive(false);
            elife -= 50;
        }
    }

}