using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private GameObject rootMenuPanel;
	private GameObject singlePlayerSelectPanel;
    private GameObject multiPlayerSelectPanel;

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
        player1.SetActive(false);
        player2.SetActive(false);
        rootMenuPanel.SetActive(true);
        multiPlayerSelectPanel.SetActive(false);
    }
    #endregion
}
