using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
#region Var decleration
    Transform character;
    public float speed;
    public float targetTime;
    private float restartTargetTime = 5.0f;
    public float bulletSpeed;
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
    public KeyCode shoot;
    public KeyCode dropWeapon;
    public KeyCode firstWeapon;
    public KeyCode secondWeapon;
    public GameObject[] weapons;
    public int weaponsInInventory;
    public int currentlySelectedWeapon;
    public GameObject bullet;
    public GameObject slime;
    #endregion 

    // Start is called before the first frame update
    void Start()
    {
        weaponsInInventory = 0;
        currentlySelectedWeapon = 0;
        slime =  GameObject.FindWithTag("slime");

        speed = 5;
        if (this.name == "CharacterA")
        {
            character = GameObject.Find("CharacterA").GetComponent<Transform>();
            up = KeyCode.W;
            down = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
            dropWeapon = KeyCode.Q;
            shoot = KeyCode.LeftShift;
            firstWeapon = KeyCode.Alpha1;
            secondWeapon = KeyCode.Alpha2;

        } 
        else if (this.name == "CharacterB")
        {
            character = GameObject.Find("CharacterB").GetComponent<Transform>();
            up = KeyCode.UpArrow;
            down = KeyCode.DownArrow;
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            dropWeapon = KeyCode.RightControl;
            shoot = KeyCode.RightShift;
            firstWeapon = KeyCode.Keypad1;
            secondWeapon = KeyCode.Keypad2;
        }
        sR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigbod = this.GetComponent<Rigidbody2D>();
    }

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
        if(Input.GetKeyDown(dropWeapon) == true)
        {
            weapons[currentlySelectedWeapon] = null;
            weaponsInInventory--;
        }
        if (Input.GetKeyDown(shoot) == true)
        {
            Transform shotPointTransform = this.GetComponentInChildren<Transform>();
            //changes position of bullet spawning point
            if(sR.flipX == true)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x-0.5f, shotPointTransform.position.y, shotPointTransform.position.z);
                GameObject go = Instantiate(bullet, shotPoint, Quaternion.Euler(0, 180, 0));
                go.GetComponent<Rigidbody2D>().velocity = new Vector2 (-1,0) * bulletSpeed;
            } 
            else if(sR.flipX == false)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x+0.5f, shotPointTransform.position.y, shotPointTransform.position.z); 
                GameObject go = Instantiate(bullet, shotPoint, Quaternion.identity); 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2 (1,0) * bulletSpeed; 
            }
            
        }
        if (Input.GetKeyDown(firstWeapon))
        {
            currentlySelectedWeapon = 0;
        } else if (Input.GetKeyDown(secondWeapon))
        {
            currentlySelectedWeapon = 1;
        }
        //timer for power ups
        if (speed == 1 || speed == 7){
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                speed = 5;
                targetTime = restartTargetTime;
            }
        }        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "TilemapGround")
        {
            firstJump = false;
            secondJump = false;
            Debug.Log("I hit the ground");
        }
        if (col.gameObject.tag == "banana")
        {
            col.transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            col.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            Debug.Log("Collided with " + col.gameObject.name);
            weapons[weaponsInInventory]= col.gameObject;
            weaponsInInventory ++;
        }
        if (col.gameObject.tag == "slime"){
            Destroy(col.gameObject);
            speed = 1;
        }
        if (col.gameObject.tag == "up"){
            Destroy(col.gameObject);
            speed = 7;
        }
        if (col.gameObject.tag == "spikes"){
            Destroy(gameObject);
        }
    }  
}

 
    