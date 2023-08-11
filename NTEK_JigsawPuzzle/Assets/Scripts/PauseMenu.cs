using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject TimerUI;
    public GameObject BoardHolder;
    public GameObject TrayHolder;
    public GameObject SelectionHolder;
    [SerializeField] private AudioSource BGM;
    [SerializeField] private AudioSource buttonTrigger;

    public GameObject InstructionsHolder;
    public GameObject pauseMenuUI;
    // Update is called once per frame

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                buttonTrigger.Play();
                Resume();
            }
            else
            {
                buttonTrigger.Play();
                Pause();
            }
        }
    }

    public void PlayGame()
    {
        InstructionsHolder.SetActive(false);
        TimerUI.SetActive(true);
        BoardHolder.SetActive(true);
        TrayHolder.SetActive(true);
        SelectionHolder.SetActive(true);
        Time.timeScale = 1f;
        BGM.Play();
    }

    public void Resume()
    {
        TimerUI.SetActive(true);
        BoardHolder.SetActive(true);
        TrayHolder.SetActive(true);
        SelectionHolder.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        BGM.Play();
    }

    void Pause()
    {
        TimerUI.SetActive(false);
        BoardHolder.SetActive(false);
        TrayHolder.SetActive(false);
        SelectionHolder.SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        BGM.Pause();
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
