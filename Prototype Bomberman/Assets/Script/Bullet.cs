using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
 
         if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        
        Destroy(gameObject);
        if (other.gameObject.tag == "Player")
        {
            LifeController lives = other.gameObject.GetComponent<LifeController>();
            lives.lives--;
        }
    }
    void timerEnded()
    {
        Destroy(gameObject);
    }
}

