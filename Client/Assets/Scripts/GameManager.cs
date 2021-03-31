using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int currentPlayer = 1;
    private bool choosingInteraction = false;

    private bool useNetwork=MainMenu.useNetwork;
    private NetworkManager networkManager;

    public GameObject character1;
    public GameObject character2;
    public GameObject enemy;
    
    private GameObject char1;
    private GameObject char2;
    private GameObject en;

    public static bool alive;
    void Start()
    {
        alive=false;
        DontDestroyOnLoad(this.gameObject);
        //character = GameObject.FindWithTag("Player");
        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        MessageQueue msgQueue = networkManager.GetComponent<MessageQueue>();
        msgQueue.AddCallback(Constants.SMSG_MOVE, OnResponseMove);
        msgQueue.AddCallback(Constants.SMSG_ENEMY, OnResponseEnemy);
        msgQueue.AddCallback(Constants.SMSG_INTERACT, OnResponseInteract);
    }

    void Update()
    {
        
    }

    public void OnlineMovement(float x, float y,float angle)
    {
        if(networkManager.IsConnected()==true){
            networkManager.SendMoveRequest(x, y,angle);
        };

    }
    public void EnemyOnlineMovement(float x, float y)
    {
        if(networkManager.IsConnected()==true){
            networkManager.SendEnemyRequest(x, y);
        };

    }
    public void EnemyKilled()
    {
        Destroy(en);
        alive=false;
    }

    public void SpawnPlayers()
    {
        if(networkManager.IsConnected()==false)
        {
            if(PlayerPrefs.GetString("Player")=="Player1")
            {
                char1=Instantiate(character1, new Vector3(0,60,-300), Quaternion.identity);
            }
            if(PlayerPrefs.GetString("Player")=="Player2")
            {
                char2=Instantiate(character2, new Vector3(0,60,-300), Quaternion.identity);
            }
        }
        else
        {
            char1=Instantiate(character1, new Vector3(0,60,-300), Quaternion.identity);
            char2=Instantiate(character2, new Vector3(100,60,-300), Quaternion.identity);
        }
    }
    
    public void SpawnEnemy()
    {
        en=Instantiate(enemy, new Vector3(0,60,300), Quaternion.identity);
        alive=true;
    }

	public void OnResponseMove(ExtendedEventArgs eventArgs)
	{
		ResponseMoveEventArgs args = eventArgs as ResponseMoveEventArgs;
        float x=args.x;
        float y=args.y;
        float angle=args.angle;
        //Debug.Log(x+" " +y);
        char1.GetComponent<PlayerAction>().move(x,y);
        char1.GetComponent<PlayerAction>().rotate(angle);
        
        char2.GetComponent<PlayerAction>().move(x,y);
        char2.GetComponent<PlayerAction>().rotate(angle);
		
	}

    public void OnResponseEnemy(ExtendedEventArgs eventArgs)
	{
		ResponseEnemyEventArgs args = eventArgs as ResponseEnemyEventArgs;

        float x=args.x;
        float y=args.y;

        en.GetComponent<EnemyMovement>().moveEnemy(x,y);
		
	}

	public void OnResponseInteract(ExtendedEventArgs eventArgs)
	{
		
	}

    private void OnApplicationQuit()
    {
        Debug.Log("Send LeaveReq");
        networkManager.SendLeaveRequest();
        GameObject.Destroy(char1);
        GameObject.Destroy(char2);
        GameObject.Destroy(enemy);
        PlayerPrefs.DeleteAll();
    }
}
