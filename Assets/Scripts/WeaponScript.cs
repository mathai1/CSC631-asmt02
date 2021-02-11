using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    [SerializeField]
    Transform pointOfFire;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float attackSpeed;

    private float lastShot = 0;
    public static WeaponScript gun;

    //Awake is called when the object is initialized
    void Awake(){
        gun = GetComponent<WeaponScript>();
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
