using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private string p1Name = "Player 1";
    private string p2Name = "Player 2";

    private GameObject rootMenuPanel;
	private GameObject singlePlayerSelectPanel;
    private GameObject multiPlayerSelectPanel;

    private NetworkManager networkManager;
    private MessageQueue msgQueue;

    // Start is called before the first frame update
    void Start()
    {
        rootMenuPanel = GameObject.Find("RootMenu");
		singlePlayerSelectPanel = GameObject.Find("SinglePlayerSelect");
        multiPlayerSelectPanel = GameObject.Find("MultiPlayerSelect");

        player1.SetActive(false);
        player2.SetActive(false);

        rootMenuPanel.SetActive(true);
        singlePlayerSelectPanel.SetActive(false);
        multiPlayerSelectPanel.SetActive(false);

        networkManager = GameObject.Find("Network Manager").GetComponent<NetworkManager>();
        msgQueue = networkManager.GetComponent<MessageQueue>();

        msgQueue.AddCallback(Constants.SMSG_JOIN, OnResponseJoin);
        msgQueue.AddCallback(Constants.SMSG_LEAVE, OnResponseLeave);
        msgQueue.AddCallback(Constants.SMSG_SETNAME, OnResponseSetName);
    }
    #region RootMenu
    //when single player button is clicked
    public void OnSinglePlayerClick()
	{
		rootMenuPanel.SetActive(false);
        singlePlayerSelectPanel.SetActive(true);
        PlayerPrefs.DeleteAll();
        player1.SetActive(true);
        player2.SetActive(true);
	}

    //when multiplayer button is clicked
    public void OnMultiplayerClick()
    {
        Debug.Log("Send JoinReq");
        bool connected = networkManager.SendJoinRequest();
        if (!connected)
        {
            Debug.Log("Cannot join the server");
            return;
        }
        rootMenuPanel.SetActive(false);
        multiPlayerSelectPanel.SetActive(true);
        PlayerPrefs.DeleteAll();
        player1.SetActive(true);
        player2.SetActive(true);
    }
    #endregion


    #region SinglePlayerMenu
     public void SelectFirstPlayer()
    {
        //for select character 1 on character selection screen
        PlayerPrefs.SetString("Player","Player1");
        player1.SetActive(true);
        player2.SetActive(false);
    }

    public void SelectSecondPlayer()
    {
        //for select character 2 on character selection screen
        PlayerPrefs.SetString("Player","Player2");
        player1.SetActive(false);
        player2.SetActive(true);
    }

    //for when user clicks confirm button
    public void OnConfirmClick()
    {
        if(PlayerPrefs.HasKey("Player")==true){
            SceneManager.LoadScene("BattleRoom");
        }
        else{
            Debug.Log("Please Select a Character");
        }
    }

    //for when user clicks back button
    public void OnBackClick()
    {
        player1.SetActive(false);
        player2.SetActive(false);
        rootMenuPanel.SetActive(true);
        singlePlayerSelectPanel.SetActive(false);
    }
    #endregion

    #region MultiPlayerMenu

    public void OnLeaveClick()
    {
        Debug.Log("Send LeaveReq");
        networkManager.SendLeaveRequest();
        player1.SetActive(false);
        player2.SetActive(false);
        rootMenuPanel.SetActive(true);
        multiPlayerSelectPanel.SetActive(false);
    }

    public void OnJoinClick()
    {
        Debug.Log("Starting Game");
        networkManager.SendJoinRequest();
        if (PlayerPrefs.HasKey("Player") == true)
        {
            SceneManager.LoadScene("BattleRoom");
        }
        else
        {
            Debug.Log("Please Select a Character");
        }
    }
    #endregion

    public void OnResponseJoin(ExtendedEventArgs eventArgs)
    {
        ResponseJoinEventArgs args = eventArgs as ResponseJoinEventArgs;
        if(args.status == 0)
        {
            Debug.Log("status is 0");
            if (args.user_id == 1)
            {
                PlayerPrefs.SetString("Player", "Player1");
                Debug.Log("Welcome, Player" + args.user_id);
            }
            else if (args.user_id == 2)
            {
                PlayerPrefs.SetString("Player", "Player2");
                Debug.Log("Welcome, Player" + args.user_id);
            }
            else
            {
                Debug.Log("Error : invalid user_id in ResponseJoin " + args.user_id);
                return;
            }
        }
        
    }

    public void OnResponseLeave(ExtendedEventArgs eventArgs)
    {
        ResponseLeaveEventArgs args = eventArgs as ResponseLeaveEventArgs;
    }

    public void OnResponseSetName(ExtendedEventArgs eventArgs)
    {
        ResponseSetNameEventArgs args = eventArgs as ResponseSetNameEventArgs;
    }

}
