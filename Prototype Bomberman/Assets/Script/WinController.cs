using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinController : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public Text winText;

    private void Start() 
    {
        player1 = GameObject.Find("CharacterA");
        player2 = GameObject.Find("CharacterB");
        winText.text = "";
    }
    
    // Update is called once per frame
    void Update()
    {
        if (player1 == null) { winText.text = "Player 2 won!";}
        if (player2 == null) { winText.text = "Player 1 won!";} 
    }
}
