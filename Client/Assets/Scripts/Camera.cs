using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject player1camera;
    public GameObject player2camera;
    public Transform player;
    void Start()
    {
        //get the character that player chooses during character selection
        if (PlayerPrefs.GetString("Player")=="Player1"){
            player1.SetActive(true);
            player1camera.SetActive(true);
            player2.SetActive(false);
            player2camera.SetActive(false);
            player=player1.transform;
        }
        if (PlayerPrefs.GetString("Player")=="Player2"){
            player2.SetActive(true);
            player2camera.SetActive(true);
            player1.SetActive(false);
            player1camera.SetActive(false);
            player=player2.transform;
        }
    }
    public Vector3 offset;
    // Update is called once per frame
    void Update()
    {
        transform.position=player.position +offset;
    }
}
