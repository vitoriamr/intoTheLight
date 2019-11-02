using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_MaxSlimeSpeed = 3f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_Slide = 4f;                        // The fastest the player can slide in the x axis.
        [SerializeField] private float m_JumpForce = 300f;                  // Amount of force added when the player jumps.
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = 1f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private bool ice = false;
        private bool slime = false;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius);
            
            if(colliders.Length == 1) 
            { 
                ice = false;
                slime = false; 
            }

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject){
                    if(colliders[i].gameObject.tag == "Ice"){
                        ice = true;
                    } else {
                        ice = false;
                    };
                    if(colliders[i].gameObject.tag == "Slime"){
                        slime = true;
                    } else {
                        slime = false;
                    };
                    m_Grounded = true;
                    if(colliders[i].gameObject.tag == "Enemy"){
                        SceneManager.LoadScene("sec");
                    };
                }
            }
        }


        public void Move(float move, bool jump)
        {   
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {                          
                // Ice ground movement
                if (ice)
                {
                    if(m_FacingRight && move == 0)
                    {
                        m_Rigidbody2D.velocity = new Vector2(1*m_Slide, m_Rigidbody2D.velocity.y);
                    } 
                    if(!m_FacingRight && move == 0) 
                    {
                        m_Rigidbody2D.velocity = new Vector2(-1*m_Slide, m_Rigidbody2D.velocity.y);
                    }

                    if(m_FacingRight && move > 0 )
                    {
                        m_Rigidbody2D.velocity = new Vector2(1*(m_Slide+m_MaxSpeed), m_Rigidbody2D.velocity.y);
                    }
                    if(!m_FacingRight && move > 0)
                    {
                        m_Rigidbody2D.velocity = new Vector2(-1*(m_Slide+m_MaxSpeed), m_Rigidbody2D.velocity.y);
                    }
                }
                //Slime ground move
                else if (slime)
                {
                    m_Rigidbody2D.velocity = new Vector2(move*m_MaxSlimeSpeed, m_Rigidbody2D.velocity.y);
                } 
                
                //Normal move
                else {
                    m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);
                }

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip(); 
                }
            }
            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                if(!slime) {
                    m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                }
                if (slime) {
                    m_Rigidbody2D.AddForce(new Vector2(0f, 250f));
                }
                
            }

        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
