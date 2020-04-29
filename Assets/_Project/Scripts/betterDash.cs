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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (directionH == 0)
        {
            if (Input.GetButtonDown("Dash"))
            {
                moveInput = Input.GetAxis("Horizontal");
                 if (moveInput < 0)
                {
                    directionH = 1;
                }
                else if (moveInput > 0)
                {
                    directionH = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                directionH = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (directionH == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (directionH == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
            }
        }

        if (directionV == 0)
        {
            if (Input.GetButtonDown("Dash"))
            {
                moveInput = Input.GetAxis("Vertical");
                 if (moveInput < 0)
                {
                    directionV = 1;
                }
                else if (moveInput > 0)
                {
                    directionV = 2;
                }
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                directionV = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (directionV == 1)
                {
                    rb.velocity = Vector2.down * dashSpeed;
                }
                else if (directionV == 2)
                {
                    rb.velocity = Vector2.up * dashSpeed;
                }
            }
        }
    }
}