using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    public Transform player;
    private Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
 
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //finds the angle between  where the enemy is currently facing and the player
        Vector3 direction =player.position-transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        rb.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));

        direction.Normalize();
        movement =direction;
    }
    void FixedUpdate(){
        moveEnemy(movement);
    }
    void moveEnemy(Vector3 direction){
        rb.MovePosition(transform.position +(direction *moveSpeed *Time.deltaTime));
    }

    void OnCollisionEnter(Collision other)
    {
            Debug.Log("Enemy hit");
    }
}
