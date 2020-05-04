using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllersAnimatorController : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void UpdateJumpAnimation(){
        animator.SetInteger("Key", key);
    }
    // Update is called once per frame
    public float respawnTime = 120f;
    public float actualRespawnTime;
    public int key = 1;
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Awake()
    {
        actualRespawnTime = respawnTime;
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
    }
    private void FixedUpdate() {
        UpdateJumpAnimation();
        if (actualRespawnTime > 0)
            --actualRespawnTime;
        if (key < 4){
            if (actualRespawnTime < 1){
                ++key;
                actualRespawnTime = respawnTime;
            }
        }
        if (key == 4){
            key = 1;
            actualRespawnTime = respawnTime;
        }
    }
}
