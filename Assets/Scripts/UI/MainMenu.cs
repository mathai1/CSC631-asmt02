using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private GameObject rootMenuPanel;
	private GameObject characterSelectPanel;

    // Start is called before the first frame update
    void Start()
    {
        rootMenuPanel = GameObject.Find("RootMenu");
		characterSelectPanel = GameObject.Find("CharacterSelect");

        rootMenuPanel.SetActive(true);
        characterSelectPanel.SetActive(false);
    }

    //when single player button is clicked
    public void OnSinglePlayerClick()
	{
		rootMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(true);
	}

    //when multiplayer button is clicked
    public void OnMultiplayerClick()
    {
        rootMenuPanel.SetActive(false);
        characterSelectPanel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
