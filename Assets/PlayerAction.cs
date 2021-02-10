using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Rigidbody rb;

   public float speed = 50;
 
     void Update () {
         Vector3 pos = transform.position;
 
         if (Input.GetKey ("w")) {
             pos.z += speed * Time.deltaTime;
         }
         if (Input.GetKey ("s")) {
             pos.z -= speed * Time.deltaTime;
         }
         if (Input.GetKey ("d")) {
             pos.x += speed * Time.deltaTime;
         }
         if (Input.GetKey ("a")) {
             pos.x -= speed * Time.deltaTime;
         }
         transform.position=pos;    
     }
}
