using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController2D))]

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D m_controller;
    public CharacterController2D controller
    {
        get
        {
            if (m_controller == null)
            m_controller = GetComponent<CharacterController2D>();
            return m_controller;
        }
    }

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate ()
    {
        
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;

    }
}
