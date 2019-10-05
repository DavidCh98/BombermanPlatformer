using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject playAgainUI;
    public GameObject player1;
    public GameObject player2;
    public Text winText;

        private void Start() 
    {
        player1 = GameObject.Find("CharacterA");
        player2 = GameObject.Find("CharacterB");
        winText.text = "";
    }

    public void PlayGame(){
        SceneManager.LoadScene("Game");
    }
    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame(){
        Application.Quit();
        Debug.Log("You quited");
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
          if (player1 == null) 
        { 
            winText.text = "Player 2 won!";
            playAgainUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (player2 == null) 
        { 
            winText.text = "Player 1 won!";
            playAgainUI.SetActive(true);
            Time.timeScale = 0f;
        } 
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
