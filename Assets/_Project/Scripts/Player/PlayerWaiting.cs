using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
[RequireComponent(typeof(PlayerMovementController))]
public class PlayerIdle : MonoBehaviour
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
    public bool isIdle;
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
            isIdle = true;
        }else{
            isIdle = false;
        }
        if (PlayerStateInfo.Instance.playerJump.isJumping){
        isIdle = false;
        actualWaitingTime = waitingTime;
        }
    }
    //Update Movement of the Player 
    private void Update() {
        UpdateWaiting();
    }
}
