using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 pointOfFire;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private GameObject hitPrefab;

    void Start()
    {
        pointOfFire = transform.position;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
         ContactPoint contact = other.contacts[0];
         Vector3 collidePoint = contact.point;
         Quaternion rotation = Quaternion.FromToRotation (Vector3.up,contact.normal);

         Instantiate(hitPrefab, collidePoint, rotation);
         Destroy(this.gameObject);
    }
}
