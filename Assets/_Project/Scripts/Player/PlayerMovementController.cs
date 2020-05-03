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
            return m_speed;
        }
        set{
            m_speed = value;
        }
    }    
    public float currentMoveDirection;
    public float m_speed = 5f;
    public bool allowModifySpeed = true;
    public bool isWalking;
    public string songName;
    private float numberOfPlays = 1;
    public void UpdateWalking(){
        if (currentMoveDirection != 0){
            if (PlayerStateInfo.Instance.playerJump.isJumping == false){
                isWalking = true;
            }
        }
        if (currentMoveDirection == 0 || PlayerStateInfo.Instance.playerJump.isJumping == true){
            isWalking = false;
        }
    }
    public float loopTime = 0.20f * 60f;
    public float actualLoopTime;
    public bool canPlaySound;
    public void PlayerWalkingSound(){
        if(isWalking){
            if (numberOfPlays == 1){

                canPlaySound = true; 
                --numberOfPlays;
            }     
        }else{
            numberOfPlays = 1;
            canPlaySound = false;
        }
    }
    public void UpdateLoopTime(){
        if(canPlaySound){
            if (actualLoopTime > 0){
                --actualLoopTime;
            }else{
                AudioManager.Instance.Play(songName); 
                actualLoopTime = loopTime;
            }
        }
    }
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        actualLoopTime = loopTime;
    }
    private void FixedUpdate() {
        UpdateMovement();
        UpdateWalking();   
        UpdateLoopTime();
        PlayerWalkingSound();    
    }
    void UpdateMovement(){
        rb.velocity = new Vector2(playerInputs.HorizontalAxis * speed, rb.velocity.y);
        currentMoveDirection = (playerInputs.HorizontalAxis);
    }




   
   
}
