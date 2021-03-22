using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{
    public static int gold= PlayerAction.gold;
    public GameObject goldObj;
    
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Boss drop collision
        if (collisionInfo.collider.tag=="Player")
        {
            Debug.Log(gold);
            gold += 100;
            goldObj.SetActive(false);
            Debug.Log(gold);
        }
    }
}
