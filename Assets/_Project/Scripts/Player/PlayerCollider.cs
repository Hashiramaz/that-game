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
            PlayerStateInfo.Instance.playerDash.currentTimeBetweenDash = 0;
            PlayerStateInfo.Instance.playerDash.isOnDash = false;
            PlayerStateInfo.Instance.playerDash.canUseDash = true;
        }
        if (collisionInfo.collider.tag == "Trash"){
            PlayerStateInfo.Instance.playerDash.extraDashes = -1;
        }
    }
}
