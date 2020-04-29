using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class betterDash : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int directionH;
    private int directionV;
    private float moveInput;
    public bool isOnDash;
    public bool canUseDash
    {
        get
        {
            return !isOnDash;
        }
    }
    public Vector2 dashDirection;
    public float currentDashTime;
    private bool buttonDashPressed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
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
                rb.velocity = Vector2.zero;
                isOnDash = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateDashMoviment();
        UpdateDashInput();
    }
}