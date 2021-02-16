using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    public GameObject treasure;
    public GameObject gold;
    // Start is called before the first frame update
    void Start()
    {
        treasure.SetActive(true);
        gold.SetActive(false);

    }
    void OnMouseDown()
    {
        //when treasure object is clicked upon
        gold.transform.position= transform.position;
        treasure.SetActive(false);
        gold.SetActive(true);

    }   
    
}
