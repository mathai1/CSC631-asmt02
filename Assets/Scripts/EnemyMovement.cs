using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    public Transform player;
    public GameObject enemy;
    public GameObject player1;
    public GameObject player2;
    public GameObject gold;
    private Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
    public int health;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
        enemy.SetActive(true);
        gold.SetActive(false);
        if (PlayerPrefs.GetString("Player")=="Player1"){
            player=player1.transform;
        }
        if (PlayerPrefs.GetString("Player")=="Player2"){
            player=player2.transform;
        }
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
        //if health is 0 or less then set active to false and gold drop to true
        if (health <= 0)
        {
            gold.transform.position=transform.position;
            enemy.SetActive(false);
            gold.SetActive(true);
        }
    }
    void FixedUpdate(){
        var distance = Vector3.Distance(player.position, transform.position);
        Debug.Log(distance);
        if (distance > 200f){ moveEnemy(movement); }
        else {
            EnemyShoot.shot.Shoot();
        }
        transform.LookAt(player);
    }
    void moveEnemy(Vector3 direction){
        rb.MovePosition(transform.position +(direction *moveSpeed *Time.deltaTime));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag=="Bullet")
        {
           health-=25;
        }
    }
}
