using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
   public GameObject bullet;
   void OnCollisionEnter2D(Collision2D other)
    {
        // the tilemap component
        Tilemap tm = GetComponent<Tilemap>();
        // its grid
        GridLayout grid = tm.layoutGrid;
        // get one of the contact's position (I suppose any position would do)
        Vector3 cp = other.GetContact(0).point;
        // convert from world position to grid position
        Vector3Int celPos = grid.WorldToCell(new Vector3(cp.x, cp.y, 0));
        // remove the tile from the tilemap
        if (other.gameObject.tag == "bullet"){
            tm.SetTile(celPos, null);
            
        }
        Debug.Log(other.gameObject.tag);
           
    }
}
