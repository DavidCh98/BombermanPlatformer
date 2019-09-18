using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    [SerializeField]
    public int score;
    [SerializeField]
    private Text scoreField;

    private GameObject hitPlayer;
    private GameObject otherPlayer;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        if (this.name == "CharacterA")
        {
            hitPlayer = GameObject.Find("CharacterA");
            otherPlayer =GameObject.Find("CharacterB");
        } 
        else if (this.name == "CharacterB")
        {
            hitPlayer = GameObject.Find("CharacterB");
            otherPlayer = GameObject.Find("CharacterA");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreField.text = "Score: " + score;   
    }
}
