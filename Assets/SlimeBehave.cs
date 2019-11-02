using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehave : MonoBehaviour
{
    private bool revert;
    void Start()
    {
        revert = false;    
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Flip()
    {
        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    } 

    private void Move()
    {
        if(!revert) {
            transform.Translate(2*Time.deltaTime,0,0);
        } else {
            transform.Translate(-2*Time.deltaTime,0,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.CompareTag("Limit")){
            revert = !revert;
            Flip();
        }
    }
}
