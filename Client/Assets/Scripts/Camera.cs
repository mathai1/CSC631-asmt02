using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    GameObject player;

    void Start()
    {
       //player=GameObject.FindWithTag("Player");

    }
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = GameObject.FindWithTag("Player").transform.position + offset;
    }
}
