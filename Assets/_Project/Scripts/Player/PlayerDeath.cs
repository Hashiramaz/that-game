using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    public bool isDead;
    public string deathSound;
    public float respawnTime = 90f;
    public float actualRespawnTime;
    private float numberOfPlays = 1;
    public void Death()
    {
        isDead = true;
        if (numberOfPlays == 1){
            FindObjectOfType<AudioManager>().Play(deathSound);
            --numberOfPlays;
        }
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        actualRespawnTime = respawnTime;
    }
    
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        if (isDead == true)
        {
           --actualRespawnTime; 
        }
        if (isDead == true && actualRespawnTime < 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isDead = false;
            numberOfPlays = 1;
        }
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.tag == "Death Threat")
        Death();
    }
}
