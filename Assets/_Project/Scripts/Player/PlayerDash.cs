using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private float moveInput;
    public bool isOnDash;
    public bool canUseDash
    {
        get
        {
            return !isOnDash && currentTimeBetweenDash == 0 && actualExtraDashes >= 0;
        }
    }
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
        if (Input.GetButtonDown("Dash") && !buttonDashPressed)
        {
            buttonDashPressed = true;
            TryUseDash();
        }
        if (Input.GetButtonUp("Dash") && buttonDashPressed)
        {
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
    }
    public void SetDashDirection()
    {
        dashDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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
    public string songName;
    public void PlayerDashingSound(){
        if(isOnDash){
            if (numberOfPlays == 1){
                AudioManager.Instance.Play(songName); 
                --numberOfPlays;
            }   
        }
        if(canUseDash){
            numberOfPlays = 1;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateDashMoviment();
        UpdateDashInput();
        UpdateTimeBetweenDash();
        UpdateDashRestart();
        PlayerDashingSound();
    }
}