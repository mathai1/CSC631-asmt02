using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    float change = -90f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotateLight();
//        transform.RotateAround(Vector3.zero,Vector3.right,6f*Time.deltaTime);
//        transform.LookAt(Vector3.zero);
    }

    void rotateLight()
    {
        //Hit F to swap day and night
        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.Rotate(new Vector3(change,0f,0f));
            if (change > 0f) change -= 180f;
            else change += 180f;
        }
    }
}
