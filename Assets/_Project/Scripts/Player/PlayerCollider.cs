using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Food"){
            PlayerStateInfo.Instance.playerDash.extraDashes++;
        }
        if (collisionInfo.collider.tag == "Trash"){
            PlayerStateInfo.Instance.playerDash.extraDashes = -1;
        }
    }
}
