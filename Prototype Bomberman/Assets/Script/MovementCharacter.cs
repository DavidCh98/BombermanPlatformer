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
    private bool bugJump;
    private Rigidbody2D rigbod;
    private SpriteRenderer sR;
    public KeyCode up;
    public KeyCode left;
    public KeyCode right;
    public KeyCode shoot;
    public KeyCode spawnTile;
    public GameObject tile;
    public GameObject weapon;
    public GameObject weaponSprite;
    public GameObject bullet;
    public GameObject slime;
    private bool haveGun;
    private bool allowSpawn = false;
    private Vector2 playerPos;
     [SerializeField] 
    #endregion 

    // Start is called before the first frame update
    void Start()
    {

        slime =  GameObject.FindWithTag("slime");

        speed = 5;
        if (this.name == "CharacterA")
        {
            character = GameObject.Find("CharacterA").GetComponent<Transform>();
            up = KeyCode.W;
            left = KeyCode.A;
            right = KeyCode.D;
            shoot = KeyCode.LeftShift;
            spawnTile =  KeyCode.F;

        } 
        else if (this.name == "CharacterB")
        {
            character = GameObject.Find("CharacterB").GetComponent<Transform>();
            up = KeyCode.UpArrow;
            left = KeyCode.LeftArrow;
            right = KeyCode.RightArrow;
            shoot = KeyCode.RightShift;
            spawnTile =  KeyCode.Keypad0;
        }
        sR = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rigbod = this.GetComponent<Rigidbody2D>();

        playerPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
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
        } else if (Input.GetKeyDown(up) == true && firstJump == true && secondJump == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
            secondJump = true;
            Debug.Log("Jumping2");
        } else if (Input.GetKeyDown(up) == true && firstJump == true && secondJump == false && bugJump == false){
            rigbod.velocity = new Vector2(rigbod.velocity.x, jumpForce);
            bugJump = true;
        }
         
        if(Input.GetKey(right))
        {
            rigbod.velocity = new Vector2(speed, rigbod.velocity.y);
            sR.flipX = false;
            animator.SetBool("CharacterAnimation",true);
            animator.SetBool("AnimationA",true);
        }
        if(Input.GetKey(left))
        {
            rigbod.velocity = new Vector2(-speed, rigbod.velocity.y);
            sR.flipX = true;
            animator.SetBool("CharacterAnimation",true);
            animator.SetBool("AnimationA",true);
        }
        if (Input.GetKeyUp(left) == true || Input.GetKeyUp(right) == true || Input.GetKeyUp(up) == true)
        {
            animator.SetBool("CharacterAnimation",false);
            animator.SetBool("AnimationA",false);
            rigbod.velocity= new Vector2(0, rigbod.velocity.y);
        }
        if (Input.GetKeyDown(spawnTile) == true && allowSpawn == true){
            Transform shotPointTransform = this.GetComponentInChildren<Transform>();
            if(sR.flipX == true)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x-0.8f, shotPointTransform.position.y, shotPointTransform.position.z);
                Instantiate(tile, shotPoint,Quaternion.Euler(0, 180, 0));
                Debug.Log("spawnTile180");
                
            } 
            else if(sR.flipX == false)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x+0.8f, shotPointTransform.position.y, shotPointTransform.position.z); 
                Instantiate(tile, shotPoint, Quaternion.identity); 
                Debug.Log("spawnTileNormal");
            }  
        }

        if (Input.GetKeyDown(shoot) == true)
        {
            Transform shotPointTransform = this.GetComponentInChildren<Transform>();
            //changes position of bullet spawning point
            if(sR.flipX == true)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x-0.8f, shotPointTransform.position.y, shotPointTransform.position.z);
                GameObject go = Instantiate(bullet, shotPoint, Quaternion.Euler(0, 180, 0));
                go.GetComponent<Rigidbody2D>().velocity = new Vector2 (-1,0) * bulletSpeed;
            } 
            else if(sR.flipX == false)
            {
                Vector3 shotPoint = new Vector3(shotPointTransform.position.x+0.8f, shotPointTransform.position.y, shotPointTransform.position.z); 
                GameObject go = Instantiate(bullet, shotPoint, Quaternion.identity); 
                go.GetComponent<Rigidbody2D>().velocity = new Vector2 (1,0) * bulletSpeed; 
            }  
        }
        //timer for power ups
        if (speed == 1 || speed == 7 || speed == 0){
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                speed = 5;
                targetTime = restartTargetTime;
            }
        }else if (allowSpawn == true){
            targetTime -= Time.deltaTime;
            if (targetTime <= 0)
            {
                allowSpawn = false;
                targetTime = restartTargetTime;
            }
        }
        if(this.GetComponent<SpriteRenderer>().flipX == true)
        {
            weaponSprite.GetComponent<SpriteRenderer>().flipX = true;
            weaponSprite.transform.position = new Vector2(this.transform.position.x -0.4f,this.transform.position.y); 
        }
        else if (this.GetComponent<SpriteRenderer>().flipX == false)
        {
            weaponSprite.GetComponent<SpriteRenderer>().flipX = false;
            weaponSprite.transform.position = new Vector2(this.transform.position.x +0.4f,this.transform.position.y); 
        }    
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Destructable" || col.gameObject.name == "TilemapGround"  || col.gameObject.name == "tile(Clone)")
        {
            firstJump = false;
            secondJump = false;
            bugJump = false;
            Debug.Log("I hit the ground");
        }
        // if (col.gameObject.tag == "banana")
        // {
        //     col.transform.localScale = new Vector2(0.2f,0.2f);
        //     col.gameObject.GetComponent<SpriteRenderer>().flipY = false;
        //     Debug.Log("Collided with " + col.gameObject.name);
        //     weapon = col.gameObject;
        //     haveGun = true;
            
        // }
        if (col.gameObject.tag == "slime"){
            Destroy(col.gameObject);
            speed = 1;
        }
        if (col.gameObject.tag == "up"){
            Destroy(col.gameObject);
            speed = 7;
        }
        if (col.gameObject.tag == "rock"){
            Destroy(col.gameObject);
            speed = 0;
        }
          if (col.gameObject.tag == "build"){
            Destroy(col.gameObject);
            allowSpawn = true;
        }
        if (col.gameObject.tag == "spikes"){
            Destroy(gameObject);
        }
    }  
}

 
    