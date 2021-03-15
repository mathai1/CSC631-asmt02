using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        //At start of game set all characters to be true
        PlayerPrefs.DeleteAll();
        player1.SetActive(true);
        player2.SetActive(true);
    }

    public void Select1()
    {
        //for select character 1 on character selection screen
        PlayerPrefs.SetString("Player","Player1");
        player1.SetActive(true);
        player2.SetActive(false);
    }

    public void Select2()
    {
        //for select character 2 on character selection screen
        PlayerPrefs.SetString("Player","Player2");
        player1.SetActive(false);
        player2.SetActive(true);
    }
    public void Confirm()
    {
        if(PlayerPrefs.HasKey("Player")==true){
            SceneManager.LoadScene("BattleRoom");
        }
        else{
            Debug.Log("Please Select a Character");
        }
    }
}

    
