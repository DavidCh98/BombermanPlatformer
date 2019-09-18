using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementCharacterA : MonoBehaviour
{
    Transform character;
    public float speed;
    Animator animator;
    bool firstJump;
    bool secondJump;
    GameObject gunObject;
    Renderer gun;
    public GameObject bullet;
    public Transform shotPoint;
    private float timeBtwShots;
    public float startTimeBtwShots;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("CharacterA").GetComponent<Transform>(); 
        animator = GetComponent<Animator>(); 
        gunObject = character.transform.GetChild(0).gameObject; 
        gun = gunObject.GetComponent<Renderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = Vector2.zero;
        if (firstJump == true && secondJump == false && Input.GetKeyDown(KeyCode.W) == true){
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 5.0f); 
            Debug.Log("firstJump"); 
            firstJump = false;
            secondJump = true;
        }
        else if (firstJump == false && secondJump == true && Input.GetKeyDown(KeyCode.W) == true){
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
            movement = Vector2.right * speed;
            animator.SetBool("CharacterAnimation",true);
        }
        else
        {
            animator.SetBool("CharacterAnimation",false);
        }
        
        character.Translate(movement);
        if(timeBtwShots <= 0){
            if(Input.GetKeyDown(KeyCode.F) && gun.enabled == true)
            {
                Instantiate(bullet,shotPoint.position,transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }else{
            timeBtwShots -= Time.deltaTime;
        }
         if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        }     
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "TilemapGround")
        {
            firstJump = true;
            secondJump = false;
            Debug.Log("I hit the ground");
        }
        if(col.gameObject.name == "box" || col.gameObject.name == "gun")
        {
           Destroy(col.gameObject);
           gun.enabled = true;
        }
    } 
      
}

 
    