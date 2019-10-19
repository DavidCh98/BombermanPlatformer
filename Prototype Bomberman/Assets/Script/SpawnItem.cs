using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    [SerializeField]
    // private GameObject weaponToSpawn;
    // Start is called before the first frame update
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        // if(other.gameObject.name == "CharacterA" || other.gameObject.name == "CharacterB")
        // {
        //     Instantiate(weaponToSpawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        //     Destroy(this.gameObject);
        // }    
    }
}
