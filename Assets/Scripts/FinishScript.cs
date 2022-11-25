using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour
{
    public GameObject FinishMenu;

    //for finishing menu debugging
    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FinishGame();
        }
    }*/

    public void FinishGame()
    {
        TimingScript timer = GameObject.Find("Timer").GetComponent<TimingScript>();
        timer.countTime = false;
        FinishMenu.SetActive(true);
        GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;

        TextMeshProUGUI minText = GameObject.Find("FinishMinutes").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI secText = GameObject.Find("FinishSeconds").GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI millisecText = GameObject.Find("FinishMillisecs").GetComponent<TextMeshProUGUI>();    
        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<RCC_CarControllerV3>().canControl = false;

        if (timer.totalMillisec < 10)
        {
            millisecText.text = "00" + timer.totalMillisec.ToString("F0");
        }
        else if (timer.totalMillisec < 100)
        {
            millisecText.text = "0" + timer.totalMillisec.ToString("F0");
        }
        else
        {
            millisecText.text = timer.totalMillisec.ToString("F0");
        }
        if (timer.totalSec < 10)
        {
            secText.text = $"0{timer.totalSec}.";
        }
        else
        {
            secText.text = $"{timer.totalSec}.";
        }
        minText.text = $"{timer.totalMin}:";
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
