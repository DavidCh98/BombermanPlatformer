using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterA : MonoBehaviour
{
    Transform character;
    public float speed;
    Animator animator;
    bool firstJump;
    bool secondJump;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("CharacterA").GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        if (firstJump == true && secondJump == false && Input.GetKeyDown(KeyCode.W) == true ){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5.0f); 
            Debug.Log("firstJump"); 
            firstJump = false;
            secondJump = true;
        }
        else if (firstJump == false && secondJump == true && Input.GetKeyDown(KeyCode.W) == true ){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 6.5f); 
            Debug.Log("secondJump");
            secondJump = false;
        } 
         
        else if(Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            movement = Vector2.right * speed;
            animator.SetBool("CharacterAnimation",true);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            movement = -Vector2.left * speed;
            animator.SetBool("CharacterAnimation",true);
        }
        else
        {
            animator.SetBool("CharacterAnimation",false);
        }
        character.Translate(movement);
    }
        void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "TilemapGround")
        {
            firstJump = true;
            secondJump = false;
            Debug.Log("I hit the ground");
        }
    }
    
}

 
    