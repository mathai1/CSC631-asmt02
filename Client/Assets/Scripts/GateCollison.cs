using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollison : MonoBehaviour
{
    void OnCollisionEnter(Collision collisionInfo)
    {

        //checking for collision with gate and player
        if (GameManager.alive==false && collisionInfo.collider.tag=="Player")
        {
           FindObjectOfType<LevelManager>().nextLevel();
        }
    }
    
}
