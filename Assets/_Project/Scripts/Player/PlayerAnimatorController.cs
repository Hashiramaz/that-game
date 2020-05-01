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
    }
    public void UpdateWalkAnimation(){
        animator.SetBool("isWalking", PlayerStateInfo.Instance.playerMovementController.currentMoveDirection != 0);
    }
    public void UpdateWaitingTimeAnimation(){
        animator.SetBool("isWaiting", PlayerStateInfo.Instance.playerWaiting.isWaiting);
        
    }
    // Update is called once per frame
    void Update()
    {
        UpdateJumpAnimation();
        UpdateWalkAnimation();
        UpdateWaitingTimeAnimation();
    }
}
