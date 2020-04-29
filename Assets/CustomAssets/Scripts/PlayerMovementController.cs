using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerMovementController : MonoBehaviour
{
    protected PlayerInputs playerInputs{
        get{
            if(m_playerInputs == null)
                m_playerInputs = GetComponent<PlayerInputs>();
            return m_playerInputs;
        }
    }

    protected PlayerInputs m_playerInputs;
    
    public Rigidbody2D rb{
        get{
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody2D>();
            return m_rb;
        }
    }
    protected Rigidbody2D m_rb;


    public float speed{
        get{
            // if(!allowModifySpeed)
            //     m_speed = playerManager.defaultAttributes.speed;
            
            return m_speed;

        }
        set{
            m_speed = value;
        }
    }    

    public float m_speed = 5f;
    public bool allowModifySpeed = true;
    


    private void FixedUpdate() {

        UpdateMovement();   
        
                
    }

    //Update Movement of the Player 
    void UpdateMovement(){
        
        rb.velocity = new Vector2(playerInputs.HorizontalAxis * speed, rb.velocity.y);
    
    }




   
   
}
