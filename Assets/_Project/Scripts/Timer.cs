using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float respawnTime = 120f;
    public float actualRespawnTime;
    public float animationNumber = 1;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actualRespawnTime = respawnTime;
    }
    private void FixedUpdate() {
        if (actualRespawnTime > 0)
            --actualRespawnTime;
        if (animationNumber < 4){
            if (actualRespawnTime < 1){
                ++animationNumber;
            }
        }
        if (animationNumber == 4){
            animationNumber = 1;
        }
    }
}
