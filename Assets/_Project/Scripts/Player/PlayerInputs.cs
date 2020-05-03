using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    [Header("Buttons")]
   public bool Jump;
   public float HorizontalAxis;
   public float VerticalAxis;
    public bool Dash;
   public float ShootAxisTrigger;

   public bool jumpTrigger;
   public float jumpAxis;

    public float joyx_pos;
    public float joyy_pos;

   public bool ButtonSpeed;

    public bool fireButton;


    

    void Awake()
    {

    }

    void Update()
    {
        UpdateInputs();
    }

    void UpdateInputs(){
        
       
        {
            Jump = Input.GetButton("Jump");
            HorizontalAxis = Input.GetAxisRaw("Horizontal");
            Dash = Input.GetButton("Dash");


        }


    }




}
