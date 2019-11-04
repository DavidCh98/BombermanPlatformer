using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    public GameObject destroyEffect;
    [SerializeField]
    public float flyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        flyTime -= Time.deltaTime;
 
         if (flyTime <= 0.0f)
        {
            timerEnded();
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Instantiate(destroyEffect,transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (other.gameObject.tag == "Player")
        {
            LifeController lives = other.gameObject.GetComponent<LifeController>();
            lives.lives--;
            FMODUnity.RuntimeManager.PlayOneShot("Event:/SFX/Hit");
        }
    }
    void timerEnded()
    {
        Destroy(gameObject);
    }
}

