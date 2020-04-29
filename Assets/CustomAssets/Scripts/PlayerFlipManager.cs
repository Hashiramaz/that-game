using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipManager : MonoBehaviour
{
    protected PlayerInputs playerInputs{
        get{
            if(m_playerInputs == null)
                m_playerInputs = GetComponent<PlayerInputs>();
            return m_playerInputs;
        }
    }

    protected PlayerInputs m_playerInputs;


    public bool facingLeft;
    public bool loockingDown;

    private void Update() { 
        UpdateFlip();
        UpdateLoockingDown();
        
    }

    public void UpdateLoockingDown(){
        if(playerInputs.VerticalAxis< -0.3){
            loockingDown = true;
            
            }else{
            
            loockingDown = false;
            }
    }
    //Update the face the player are flipped 
    public void UpdateFlip(){
        //Refresh FlipPlayer

       
            if(facingLeft == false && playerInputs.HorizontalAxis < 0)
                Flip();
            else if(facingLeft == true && playerInputs.HorizontalAxis > 0)
                Flip();
        
        

        // if(facingLeft == false && playerInputs.joyx_pos < 0)
        //     Flip();
        // else if(facingLeft == true && playerInputs.joyx_pos > 0)
        //     Flip();
        
        
    }
    
    //Flip the Player
    void Flip(){

        facingLeft = !facingLeft;
        
        transform.Rotate(0f,180f,0f);
        
       // Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;

    }
}
