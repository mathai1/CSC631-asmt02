using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //Code From: https://www.youtube.com/watch?v=4Wh22ynlLyk
    public Transform player;
    //public GameObject player1;
    //public GameObject player2;
    public GameObject gold;
    private Rigidbody rb;
    private Vector3 movement;
    public float moveSpeed;
    public int health;

    private static GameManager gameManager;
    public float x;
    public float z;

    private bool useNetwork=MainMenu.useNetwork;
    
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody>();
        gold.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        player=GameObject.FindWithTag("Player").transform;
        //finds the angle between  where the enemy is currently facing and the player
        Vector3 direction =player.position-transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)* Mathf.Rad2Deg;
        rb.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));

        direction.Normalize();
        movement =direction;
 
        //if health is 0 or less then set active to false and gold drop to true
        if (health <= 0)
        {
            GetComponent<GameManager>().EnemyKilled();
            gold.SetActive(true);
        }
        
    }
    void FixedUpdate(){
        var distance = Vector3.Distance(player.position, transform.position);
        if(useNetwork==false){
            if (distance > 200f)
            { 
                moveEnemy(movement); 
            }
            else 
            {
                EnemyShoot.shot.Shoot();
            }
            transform.LookAt(player);
        }
        else
        {
            if (distance > 200f)
            { 
                FindObjectOfType<GameManager>().EnemyOnlineMovement(movement.x , movement.z);
            }

        }
       
    }
    public void moveEnemy(Vector3 direction){
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
