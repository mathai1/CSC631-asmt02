using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Rigidbody rb;

    public int speed;

    // Update is called once per frame
    // Code from: https://www.codegrepper.com/code-examples/csharp/unity+wasd+movement
    //movement using wasd or arrow keys
    void FixedUpdate()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += Movement * speed * Time.deltaTime;
    }
    
}
