using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePrefabScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "bullet"){
            Destroy(gameObject);
        }  
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
