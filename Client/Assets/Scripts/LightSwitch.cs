using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    //checks if the light is on, turns on light if it is off
    public bool lightOn = false;
    public Light light;

    public void Awake()
    {
        light = GetComponent<Light>();
    }

    void Update()
    {
        switchLights();
    }
    void switchLights()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (lightOn){light.intensity = 0; lightOn = false;}
            else {light.intensity = 2; lightOn = true;}
        }
    }
}
