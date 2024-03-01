using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PauseButton;
    public GameObject ControlButton;
    public GameObject ControlScreen;
    public GameObject OptionsPanel;
    public static bool GameIsPaused = false;
        AudioManager audioManager;
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
        PauseButton.SetActive(false);
        ControlButton.SetActive(false);
        ControlScreen.SetActive(false);
        OptionsPanel.SetActive(false);
        audioManager.PlaySFX(audioManager.buttonHover);
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        PauseButton.SetActive(true);
        ControlButton.SetActive(true);
        audioManager.PlaySFX(audioManager.buttonHover);
    }
    
    public void Options()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 0;
        GameIsPaused = true;
        PauseButton.SetActive(false);
        ControlButton.SetActive(false);
        ControlScreen.SetActive(false);
        OptionsPanel.SetActive(true);
        audioManager.PlaySFX(audioManager.buttonHover);
    }

    public void Controls()
    {
        ControlButton.SetActive(false);
        audioManager.PlaySFX(audioManager.buttonHover);
        ControlScreen.SetActive(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Continue();
            ControlScreen.SetActive(false);
        }
        else{
            
        }

    }
    public void Exit()
    {
        audioManager.PlaySFX(audioManager.buttonHover);
        Debug.Log("Returning to Main Menu...");
        SceneManager.LoadScene("MainMenu");
    }
}
