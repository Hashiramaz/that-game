using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
         protected PlayerInputs playerInputs{
        get{
            if(m_playerInputs == null)
                m_playerInputs = GetComponent<PlayerInputs>();
            return m_playerInputs;
        }
    }

    protected PlayerInputs m_playerInputs;
    public Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float moveInput;
    public bool isOnDash;
    public bool canUseDash;
    public Vector2 dashDirection;
    public float currentDashTime;
    private bool buttonDashPressed;
    public float timeBetweenDash = 0.5f;
    public float currentTimeBetweenDash;
    public float extraDashes = 0f;
    private float actualExtraDashes;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        actualExtraDashes = extraDashes;
    }
    public void UpdateDashInput()
    {
        if (playerInputs.Dash)
        {
            buttonDashPressed = true;
            TryUseDash();
        }else{
            buttonDashPressed = false;
        }
    }
    public void TryUseDash()
    {
        if (canUseDash)
        {
            StartDash();
        }
    }
    public void StartDash()
    {
        SetDashDirection();
        isOnDash = true;
        --actualExtraDashes;
        PlayDashSound();
    }
    public void SetDashDirection()
    {
        dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    public void UpdateDashMoviment()
    {
        if (isOnDash)
        {
            if (dashTime > 0)
            {
                dashTime -= Time.deltaTime;
                rb.velocity = dashDirection * dashSpeed;
            }
            else
            {
                dashTime = startDashTime;
                currentTimeBetweenDash = timeBetweenDash;
                rb.velocity = Vector2.zero;
                isOnDash = false;
            }
        }
    }
    public void UpdateDashRestart()
    {
        if (PlayerStateInfo.Instance.playerJump.isGrounded){
            actualExtraDashes = extraDashes;
        }
    }
    public void UpdateTimeBetweenDash()
    {
        if (currentTimeBetweenDash > 0)
        {
            currentTimeBetweenDash -= Time.deltaTime;
        }else
        {
            currentTimeBetweenDash = 0;
        }
    }
    private float numberOfPlays = 1;
    public string soundName;
    public void PlayDashSound(){
        AudioManager.Instance.Play(soundName); 
    }
    public void UpdateIfCanDash(){
        if (!isOnDash && currentTimeBetweenDash == 0 && actualExtraDashes >= 0){
            canUseDash = true;
        }else{
            canUseDash = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateDashInput();
        UpdateTimeBetweenDash();
        UpdateIfCanDash();
        UpdateDashMoviment();
        UpdateDashRestart();
    }
}