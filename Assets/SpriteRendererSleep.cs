using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRendererSleep : MonoBehaviour
{
    public Sprite sprite1;
    public Sprite sprite2; 
    private SpriteRenderer spriteRenderer; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) {
            spriteRenderer.sprite = sprite1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.frameCount%400 == 0){
            ChangeTheDamnSprite (); // call method to change sprite 
        } 
    }

    void ChangeTheDamnSprite ()
    {   
        if (spriteRenderer.sprite == sprite1) 
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1; // otherwise change it back to sprite1
        }
    }
}
