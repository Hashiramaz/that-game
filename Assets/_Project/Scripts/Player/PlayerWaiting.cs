using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerWaiting : MonoBehaviour
{
    protected PlayerInputs playerInputs{
        get{
            if(m_playerInputs == null)
                m_playerInputs = GetComponent<PlayerInputs>();
            return m_playerInputs;
        }
    }

    protected PlayerInputs m_playerInputs;

    public float waitingTime = 600f;
    private float actualWaitingTime;
    public bool isWaiting;
    private void Awake() {
        actualWaitingTime = waitingTime;
    }
    void UpdateWaiting(){
        if ((playerInputs.HorizontalAxis) == 0){
            --actualWaitingTime;
        }else{
            actualWaitingTime = waitingTime;
        }
        
        if (actualWaitingTime < 1){
            isWaiting = true;
        }else{
            isWaiting = false;
        }
        if (PlayerStateInfo.Instance.playerJump.isJumping){
        isWaiting = false;
        actualWaitingTime = waitingTime;
        }
    }
    //Update Movement of the Player 
    private void Update() {
        UpdateWaiting();
    }
}
