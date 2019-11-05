using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public SpriteRenderer maskSpriteRenderer;
    public Sprite maskSprite;
    public GameObject maskObj;
    public SpriteRenderer maskObjSpriteRender;

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "slime" || other.gameObject.tag == "rock" || other.gameObject.tag == "up" || other.gameObject.tag == "build")
        {
            maskSpriteRenderer = other.gameObject.GetComponent<SpriteRenderer>();;

            maskSprite = maskSpriteRenderer.sprite;

            maskObjSpriteRender = maskObj.GetComponent<SpriteRenderer>();
            maskObjSpriteRender.sprite = maskSprite;
        }
    }

}
