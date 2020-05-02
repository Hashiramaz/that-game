using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerJump))]
[RequireComponent(typeof(PlayerDash))]
[RequireComponent(typeof(PlayerMovementController))]
[RequireComponent(typeof(PlayerIdle))]
[RequireComponent(typeof(PlayerDeath))]
[RequireComponent(typeof(PlayerRespawn))]
public class PlayerStateInfo : MonoBehaviour
{
    public static PlayerStateInfo Instance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if (Instance == null){
            Instance = this;
        }
    }

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        playerJump = GetComponent<PlayerJump>();
        playerDash = GetComponent<PlayerDash>();
        playerMovementController = GetComponent<PlayerMovementController>();
        playerIdling = GetComponent<PlayerIdle>();
        playerDeath = GetComponent<PlayerDeath>();
        playerRespawn = GetComponent<PlayerRespawn>();
    }
    public PlayerJump playerJump;
    public PlayerDash playerDash;
    public PlayerMovementController playerMovementController;
    public PlayerIdle playerIdling;
    public PlayerDeath playerDeath;
    public PlayerRespawn playerRespawn;

}
