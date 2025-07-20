using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public static bool aboutGame;
    public GameObject aboutGameMenu;
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject thanks;
    

   
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        
        thanks.SetActive(true);
        Application.Quit();
    }
    public void AboutGame()
    {
        Time.timeScale = 1f;
        aboutGameMenu.SetActive(true);
    }
    public void Back()
    {
        Time.timeScale = 1f;
        aboutGameMenu.SetActive(false);
        
    }
   
}
