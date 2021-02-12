using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject treasure;
    // Start is called before the first frame update
    void Start()
    {
        treasure.SetActive(true);
    }
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag=="Bullet")
        {
           treasure.SetActive(false);
        }
        
    }

    
}
