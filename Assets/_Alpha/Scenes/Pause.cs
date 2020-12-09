using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public bool isPaused;
    public GameObject pauseButton;
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseButton.gameObject.activeSelf == true)
        {
            PauseGame();
            isPaused = true;
        }
        if (pauseButton.gameObject.activeSelf == false)
        {
            ResumeGame();
            isPaused = false;
        }
            

    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }
   public void ResumeGame()
    {
        Time.timeScale = 1;
    }

}


