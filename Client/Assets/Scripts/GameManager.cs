using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentPlayer = 1;
    private bool choosingInteraction = false;

    private bool useNetwork;
    private NetworkManager networkManager;

    public GameObject character1;
    public GameObject character2;
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_MOVE, OnResponseMove);
        msgQueue.AddCallback(Constants.SMSG_INTERACT, OnResponseInteract);
    }

    void Update()
    {
        
    }

    public void SpawnPlayers()
    {
        if(PlayerPrefs.GetString("Player")=="Player1")
        {
            GameObject char1=Instantiate(character1, new Vector3(0,60,-300), Quaternion.identity);
        }
        if(PlayerPrefs.GetString("Player")=="Player2")
        {
            GameObject char2=Instantiate(character2, new Vector3(0,60,-300), Quaternion.identity);
        }
    }
    
	public void OnResponseMove(ExtendedEventArgs eventArgs)
	{
		
	}

	public void OnResponseInteract(ExtendedEventArgs eventArgs)
	{
		
	}
}
