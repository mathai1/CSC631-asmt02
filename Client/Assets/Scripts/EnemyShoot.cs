using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    Transform pointOfFire;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float attackSpeed;

    private float lastShot = 0;
    public static EnemyShoot shot;

    void Awake(){
        shot = GetComponent<EnemyShoot>();
    }

    public void Shoot(){
        if (lastShot + attackSpeed <= Time.time){
            //sets lastShot to a new time
            lastShot = Time.time;

            //instantiates the bullet
            Instantiate(bulletPrefab, pointOfFire.position, pointOfFire.rotation);
        }
    }
}
