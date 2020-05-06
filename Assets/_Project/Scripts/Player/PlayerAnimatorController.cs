using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdateJumpAnimation(){
        animator.SetBool("isJumping", PlayerStateInfo.Instance.playerJump.isJumping);
        animator.SetBool("isGrounded", PlayerStateInfo.Instance.playerJump.isGrounded);
        animator.SetBool("isFalling", PlayerStateInfo.Instance.playerJump.isFalling);
    }
    public void UpdateWalkAnimation(){
        animator.SetBool("isWalking", PlayerStateInfo.Instance.playerMovementController.currentMoveDirection != 0);
    }
    public void UpdateIdleAnimation(){
        animator.SetBool("isIdling", PlayerStateInfo.Instance.playerIdling.isIdle);
        
    }
    public void UpdateDeathAnimation(){
        animator.SetBool("isDead", PlayerStateInfo.Instance.playerDeath.isDead);
    }
    // Update is called once per frame
    void Update()
    {
        UpdateJumpAnimation();
        UpdateWalkAnimation();
        UpdateIdleAnimation();
        UpdateDeathAnimation();
    }
}
