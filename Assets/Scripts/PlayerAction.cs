using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Rigidbody rb;

    public int speed;

    // Update is called once per frame
    
    void FixedUpdate()
    {
        // Code from: https://www.codegrepper.com/code-examples/csharp/unity+wasd+movement
        //movement using wasd or arrow keys
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.transform.position += Movement * speed * Time.deltaTime;
    }
    //Code from: https://answers.unity.com/questions/855976/make-a-player-model-rotate-towards-mouse-location.html
    //character rotation towards mouse 
    void Update () 
    {
         
         //Get the Screen positions of the object
         Vector2 positionOnScreen = UnityEngine.Camera.main.WorldToViewportPoint (transform.position);
         
         //Get the Screen position of the mouse
         Vector2 mouseOnScreen = (Vector2)UnityEngine.Camera.main.ScreenToViewportPoint(Input.mousePosition);
         
         //Get the angle between the points
         float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
 
         //Ta Daaa
         transform.rotation =  Quaternion.Euler (new Vector3(0f,angle,0f));

        //Shoot me pls
         ShootingUpdate();
    }
 
    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.x -b.x, a.y -b.y) * Mathf.Rad2Deg;
    }

    void ShootingUpdate()
    {
        //if left mouse button
        if (Input.GetButton("Fire1"))
        {
            WeaponScript.gun.Shoot();
        }
    }
    void OnCollisionEnter(Collision other)
    {
            Debug.Log("Player hit");
    }
    
}
