using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollision : MonoBehaviour
{
    public bool collided;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.name == "Destructable" || col.gameObject.name == "TilemapGround"  || col.gameObject.name == "tile(Clone)")
        {
            collided = true;
        }
    }
}
