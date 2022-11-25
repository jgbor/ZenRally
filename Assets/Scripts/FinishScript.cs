using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject FinishMenu;

    public void FinishGame()
    {
        GameObject.Find("Timer").GetComponent<TimingScript>().countTime = false;
        FinishMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<RCC_CarControllerV3>().canControl = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Time.timeScale = 1;
        AudioListener.pause = false;
        SceneManager.LoadScene(0);
    }
}
