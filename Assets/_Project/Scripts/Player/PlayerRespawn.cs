using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnTime = 120f;
    public float actualRespawnTime;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actualRespawnTime = respawnTime;
    }
private void FixedUpdate() {
    if (PlayerStateInfo.Instance.playerDeath.isDead)
        --actualRespawnTime;
    if (respawnTime < 1){
         PlayerStateInfo.Instance.playerDeath.isDead = false;

     }
 }
}
