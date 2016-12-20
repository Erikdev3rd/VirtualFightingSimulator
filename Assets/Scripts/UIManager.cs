using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{

    public GameObject pausePanel;
    public bool isPaused;

    // Use this for initialization
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
        {
            PauseGame(true); //same as PauseGame = true;
        }
        else
        {
            PauseGame(false);
        }

        if (Input.GetButtonDown("Cancel"))
        {
            SwitchPause(); //Pause or Unpause
        }
    }

    void PauseGame(bool state)
    {
        if (state)
        {
            Time.timeScale = 0.0f; //Paused
        }
        else
        {
            Time.timeScale = 1.0f; //Unpaused
        }
        pausePanel.SetActive(state);
    }

    public void SwitchPause()
    {
        if (isPaused)
        {
            isPaused = false; //Changes the value;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Cursor.visible = true;
        }
    }
}
