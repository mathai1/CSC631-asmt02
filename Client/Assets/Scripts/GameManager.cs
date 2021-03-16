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

	public void OnResponseMove(ExtendedEventArgs eventArgs)
	{
		
	}

	public void OnResponseInteract(ExtendedEventArgs eventArgs)
	{
		
	}
}
