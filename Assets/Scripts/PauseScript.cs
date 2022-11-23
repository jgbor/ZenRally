using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenu;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PRESSED");
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
        GameObject myEventSystem = GameObject.Find("EventSystem");
        myEventSystem .GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);
        AudioListener.pause = false;
    }

    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = true;
    
        AudioListener.pause = true;
    }

    public void Menu()
    {
        GameIsPaused = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
