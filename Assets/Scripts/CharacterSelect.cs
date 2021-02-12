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
        PlayerPrefs.DeleteAll();
        player1.SetActive(true);
        player2.SetActive(true);
    }

    public void Select1()
    {
        PlayerPrefs.SetString("Player","Player1");
        SceneManager.LoadScene("BattleRoom");
    }

    public void Select2()
    {
        PlayerPrefs.SetString("Player","Player2");
        SceneManager.LoadScene("BattleRoom");
    }
}

    
