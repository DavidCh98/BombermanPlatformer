using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public int lives;
    
    [SerializeField] 
    private GameObject[] hearts;
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "CharacterA")
        {
            player = GameObject.Find("CharacterA");
           

        } 
        else if (this.name == "CharacterB")
        {
            player = GameObject.Find("CharacterB");
            
        }
        lives = 3;
        if (this.name == "CharacterA")
        {
            hearts = GameObject.FindGameObjectsWithTag("HeartP1");
        } else if (this.name == "CharacterB")
        {
            hearts = GameObject.FindGameObjectsWithTag("HeartP2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(lives)
        {
            case 2:
                hearts[hearts.Length-1].gameObject.SetActive(false);
                break;
            case 1:
                hearts[hearts.Length-2].gameObject.SetActive(false);
                break;
            case 0:
                hearts[hearts.Length-3].gameObject.SetActive(false);
                FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/Death");
                Destroy(player);
                break;
        }
    }
}

