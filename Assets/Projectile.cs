using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 pointOfFire;

    [SerializeField]
    private float projectileSpeed;

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
        Destroy(this.gameObject);
    }
}
