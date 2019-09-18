using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{

#region Var decleration
    Transform character;
    public float speed;
    public float jumpForce = 5f;
    Animator animator;
    public bool firstJump;
    public bool secondJump;
    private Rigidbody2D rigbod;
    private SpriteRenderer sR;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
#endregion 

#region Start function
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        if (this.name == "CharacterA")
        {
            character = GameObject.Find("CharacterA").GetComponent<Transform>();
            up = KeyCode.W;
            down = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
        } 
        else if (this.name == "CharacterB")
        {
            character = GameObject.Find("CharacterB").GetComponent<Transform>();
            up = KeyCode.UpArrow;
            down = KeyCode.DownArrow;
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
        }
        sR= GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigbod = this.GetComponent<Rigidbody2D>();
    }
#endregion

#region Update function
        // Update is called once per frame
    void Update()
    {
        // Vector2 movement = Vector2.zero;

        if (Input.GetKeyDown(up) == true && firstJump == false)
        {
            Debug.Log("Jumping");
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
            firstJump = true;
        } else if (Input.GetKeyDown(up) == true && firstJump == true && secondJump == false)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
            secondJump = true;
        } 
        
         
        if(Input.GetKey(right))
        {
            rigbod.velocity = new Vector2(speed, rigbod.velocity.y);
            sR.flipX = false;
            animator.SetBool("CharacterAnimation",true);
        }
        if(Input.GetKey(left))
        {
            rigbod.velocity = new Vector2(-speed, rigbod.velocity.y);
            sR.flipX = true;
            animator.SetBool("CharacterAnimation",true);
        }
        if (Input.GetKeyUp(left) == true || Input.GetKeyUp(right) == true || Input.GetKeyUp(up) == true || Input.GetKeyUp(down) == true)
        {
            animator.SetBool("CharacterAnimation",false);
            rigbod.velocity= new Vector2(0, rigbod.velocity.y);
        }
        // character.Translate(movement);
    }
#endregion

#region Collision
            void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "TilemapGround")
        {
            firstJump = false;
            secondJump = false;
            Debug.Log("I hit the ground");
        }
    }
#endregion


    
}

 
    