using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Event : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public GameObject thankYouMenu;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    public void ReplayGame()
    {
        Debug.Log("Replay Pressed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0); 
    }

    // Update is called once per frame
    public void QuitGame()
    {
        
        thankYouMenu.SetActive(true);
        Application.Quit();
        
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
