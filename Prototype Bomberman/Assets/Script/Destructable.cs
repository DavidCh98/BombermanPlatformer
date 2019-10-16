using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Destructable : MonoBehaviour
{
   public GameObject bullet;
   public GameObject[] items;
   public Vector2 objectPos;
   public Vector3Int celPos;
   void OnCollisionEnter2D(Collision2D other)
    {
        // the tilemap component
        Tilemap tm = GetComponent<Tilemap>();
        // its grid
        GridLayout grid = tm.layoutGrid;
        // get one of the contact's position (I suppose any position would do)
        Vector3 cp = other.GetContact(0).point;
        // convert from world position to grid position
        celPos = grid.WorldToCell(new Vector3(cp.x, cp.y, 0));
        // remove the tile from the tilemap
        if (other.gameObject.tag == "bullet"){
            tm.SetTile(celPos, null);
            SpawnItem();
        }  
    }

    private void SpawnItem ()
    {
        Bullet bullet = GetComponent<Bullet>();
        int randomItem = Random.Range(0,4);
        int spawnChance = Random.Range(0, 100); 
        objectPos = new Vector2(celPos.x + 0.5f, celPos.y+0.5f);

        switch(spawnChance)
        {
            case int n when(n <=40):
                Instantiate(items[randomItem], objectPos, Quaternion.identity); 
                break;
            case int n when(n > 50 && n <= 100):
                break;
        }
        Debug.Log(randomItem + " " + spawnChance);


    }
}
