using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateCollison : MonoBehaviour
{
    public GameObject enemy;

    void OnCollisionEnter(Collision collisionInfo)
    {
        //checking for collision with gate and player
        if (enemy.activeSelf==false && collisionInfo.collider.tag=="Player")
        {
           FindObjectOfType<LevelManager>().nextLevel();
        }
    }
    
}
