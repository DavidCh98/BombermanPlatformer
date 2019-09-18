using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform character;
    Animator animator;
    public float speed;
    public float distance;
    public LayerMask whatIsSolid;
    public GameObject bullet;
    public float targetTime = 60.0f;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("CharacterA").GetComponent<Transform>();
        animator = GameObject.Find("CharacterA").GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.forward, distance, whatIsSolid);
       if (hitInfo.collider != null)
       {
           Destroy(gameObject);
           
       }
       if (character.transform.localRotation == Quaternion.Euler(0, 0, 0)){
            transform.Translate(transform.right * speed * Time.deltaTime);
       }
       else if(animator.GetBool("CharacterAnimation") == false ||animator.GetBool("CharacterAnimation") == true){
            transform.Translate(-transform.right * speed * Time.deltaTime);
       }
        targetTime -= Time.deltaTime;
 
            if (targetTime <= 0.0f)
        {
            timerEnded();
        }
        
    }
        
        void timerEnded()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other) 
        {
            LifeController lives = other.gameObject.GetComponent<LifeController>();
            ScoreController score = other.gameObject.GetComponent<ScoreController>();
            lives.lives--;
            score.score = score.score+10;
            Destroy(this.gameObject);  
        }
}

