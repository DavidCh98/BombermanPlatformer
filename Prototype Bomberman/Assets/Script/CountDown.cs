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

  void Start () {
    StartCoroutine("LoseTime");
    Time.timeScale = 1; 
    spikeLeft = GameObject.Find("spikeLeft");
    spikeRight = GameObject.Find("spikeRight");
    Timer = GameObject.Find("Timer");
  }
  void Update () {
    //Showing the Score on the Canvas
    countdown.text = ("" + timeLeft); 

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
}