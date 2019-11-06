using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class CountDown : MonoBehaviour {
  public int timeLeft = 60; 
  public Text countdown; 
  public float speed = 3f;
  private GameObject spikeLeft;
  private GameObject spikeRight;
  public GameObject Timer;
  public Image timeSprite1;
  public Image timeSprite2;
  public Sprite[] timeSprites;
  private int timeStorage;

  void Start () {
    StartCoroutine("LoseTime");
    Time.timeScale = 1; 
    spikeLeft = GameObject.Find("spikeLeft");
    spikeRight = GameObject.Find("spikeRight");
    Timer = GameObject.Find("Timer");
    timeSprite1 = timeSprite1.GetComponent<Image>();
    timeSprite2 = timeSprite2.GetComponent<Image>();
  }
  void Update () {
    //Showing the Score on the Canvas
    countdown.text = ("" + timeLeft); 
    switch(timeLeft)
    {
       case var expression when (timeLeft < 60 && timeLeft >= 50):
        timeSprite1.sprite = timeSprites[5];
        CalculateSeconds();
        break;
      case var expression when (timeLeft < 50 && timeLeft >= 40):
        timeSprite1.sprite = timeSprites[4];
        CalculateSeconds();
        break;
      case var expression when (timeLeft < 40 && timeLeft >= 30):
        timeSprite1.sprite = timeSprites[3];
        CalculateSeconds();
        break;
      case var expression when (timeLeft < 30 && timeLeft >= 20):
        timeSprite1.sprite = timeSprites[2];
        CalculateSeconds();
        break;
      case var expression when (timeLeft < 20 && timeLeft >= 10):
        timeSprite1.sprite = timeSprites[1];
        CalculateSeconds();
        break;
      case var expression when (timeLeft < 10):
        timeSprite1.sprite = timeSprites[0];
        CalculateSeconds();
        break;
    }

    if (timeLeft < 0){
        StartSpikes();
        Timer.GetComponent<Text>().enabled = false;
    }
        
        
     
        
  }
  //Simple Coroutine
  IEnumerator LoseTime()
  {
    while (true) {
      yield return new WaitForSeconds (1);
      timeLeft--; 

    }
  }
  private void StartSpikes(){
    spikeLeft.transform.Translate(speed * Time.deltaTime, 0,0);
    spikeRight.transform.Translate(-speed * Time.deltaTime, 0,0);
  }

  private void CalculateSeconds()
  {
    timeStorage = timeLeft;
    switch(timeLeft)
    {
      case var expression when (timeLeft < 60 && timeLeft >= 50):
        timeStorage -= 50;
        break;
      case var expression when (timeLeft < 50 && timeLeft >= 40):
        timeStorage -= 40;
        break;
      case var expression when (timeLeft < 40 && timeLeft >= 30):
        timeStorage -= 30;
        break;  
      case var expression when (timeLeft < 30 && timeLeft >= 20):
        timeStorage -= 20;
        break;
      case var expression when (timeLeft < 20 && timeLeft >= 10):
        timeStorage -= 10;
        break;
        
    }

    switch(timeStorage)
        {
          case 9:
            timeSprite2.sprite = timeSprites[9];
            break;
          case 8:
            timeSprite2.sprite = timeSprites[8];
            break;
          case 7:
            timeSprite2.sprite = timeSprites[7];
            break;
          case 6:
            timeSprite2.sprite = timeSprites[6];
            break;
          case 5:
            timeSprite2.sprite = timeSprites[5];
            break;
          case 4:
            timeSprite2.sprite = timeSprites[4];
            break;
          case 3:
            timeSprite2.sprite = timeSprites[3];
            break;
          case 2:
            timeSprite2.sprite = timeSprites[2];
            break;
          case 1:
            timeSprite2.sprite = timeSprites[1];
            break;
          case 0:
            timeSprite2.sprite = timeSprites[0];
            break;
        }
  }
}