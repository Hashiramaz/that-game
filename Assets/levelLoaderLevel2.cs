using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoaderLevel2 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            NextLevel();
        }
    }
    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }
}
