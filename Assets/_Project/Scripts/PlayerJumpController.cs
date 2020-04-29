using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpController : MonoBehaviour
{   
     protected PlayerInputs playerInputs{
        get{
            if(m_playerInputs == null)
                m_playerInputs = GetComponent<PlayerInputs>();
            return m_playerInputs;
        }
    }

    protected PlayerInputs m_playerInputs;



    protected Rigidbody2D rb{
        get{
            if(m_rb == null)
                m_rb = GetComponent<Rigidbody2D>();
            return m_rb;
        }
    }
    protected Rigidbody2D m_rb;

    [Header("References")]
    public Transform groundCheckBack;
    public Transform groundCheckFront;
    [Header("Settings")]
    public float m_jumpforce;
    public float jumpforce{
        get{
            // m_jumpforce = playerManager.defaultAttributes.jumpForce;
            return m_jumpforce;
        }
    }
    public float jumpTime;
    public int extraJumps;
    public float checkGroundedRadius;
    public LayerMask WhatIsGround;
    [Header("Debug Variables")]
    public bool isGrounded;
    public bool isJumping;

    public bool buttonJumpPressed;

    public int actualExtraJumps;

    public float jumpTimeCounter;

    public float actualCoyoteTime = 0.2f;
    public float coyoteTime = 0.2f;
    public void FixedUpdate() {
        UpdateJump();
        UpdateGrounded();
        UpdateCoyoteJumpTime();
    }

    //Update When The Player Can Jump
    public void UpdateJump(){
        
        //If Player is grounded reset the extra jumps they can have
        if(isGrounded){
            actualExtraJumps = extraJumps;
            actualCoyoteTime = coyoteTime;
            isJumping = false;
           
        }

        //Player Press the Button 
        if(playerInputs.Jump && !buttonJumpPressed){
            
            buttonJumpPressed = true;           
            jumpTimeCounter = jumpTime;
            // Player Can Jump if there's extra jumps
            if(actualExtraJumps >0){
                Jump();

                if(actualCoyoteTime > 0 && !isGrounded && !isJumping)
                return;
                
                isJumping = true;
                actualExtraJumps--;
            }
            else
            {
                // if not, player can jump only if is on the ground;
                if(isGrounded && actualExtraJumps == 0 && !isJumping){
                    Jump();
                    isJumping = true;
                }
               
                if ( actualCoyoteTime > 0 && !isGrounded && !isJumping ){
                    Jump();
                    isJumping = true;
                    
                  //  if(actualExtraJumps>0)
                    //    actualExtraJumps--;
                }
            } 
        }

        //If the Button Jump is pressed Called this function every time
        if(buttonJumpPressed){
           
            if(isJumping){
                
                // if(jumpTimeCounter>0){
                //     Jump();
                //     jumpTimeCounter -= Time.deltaTime;
                // }else{
                //     isJumping = false;
                // }


            }
        }
        

        //Player Release the Button
        if(!playerInputs.Jump && buttonJumpPressed){
            buttonJumpPressed = false;

            //isJumping = false;
       //     Debug.Log("Reselase Button Jump");
        }

    }

    //PLAYER jUMPS!!!
    public void Jump(){
        rb.velocity = Vector2.up * jumpforce;
    }

    //Update If The Player is od The Ground 
    public void UpdateGrounded(){
        isGrounded = (Physics2D.OverlapCircle(groundCheckBack.position,checkGroundedRadius, WhatIsGround) || Physics2D.OverlapCircle(groundCheckFront.position,checkGroundedRadius, WhatIsGround));
        
        //isJumping = !isGrounded;
    }

    public void UpdateCoyoteJumpTime(){
        if(isGrounded)
            return;

        actualCoyoteTime -= Time.deltaTime;

    }

}
