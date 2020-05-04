using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderOnEnter : MonoBehaviour
{
    
    public string sceneName;
    public bool isPressingEnter;
    public bool canEnter;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canEnter = true;
        }
    }
    public void UpdatePressingEnter(){
        if (Input.GetButton("Submit") == true){
            isPressingEnter = true;
        }
        else
        {
            isPressingEnter = false;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void UpdateCanEnter(){
        if (canEnter == true && isPressingEnter == true){
            ChangeScene();
        }
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        UpdatePressingEnter();
        UpdateCanEnter();
    }
}
