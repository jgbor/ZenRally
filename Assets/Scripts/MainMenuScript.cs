using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public static int CarNumber = 0;
    public Transform car1;
    public Transform car2;
    public Transform car3;
    public Transform car4;
    public Transform car5;
    public Transform map1;
    public Transform map2;
    public Transform map3;

    public void StartMap1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartMap2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void StartMap3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void StartMap4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void setCarNumber(int i)
    {
        CarNumber = i;
    }

    public void setAllTransformToDefault()
    {
        Vector3 newRotation = new Vector3(0, 180, 0);
        car1.eulerAngles = newRotation;
        car2.eulerAngles = newRotation;
        car3.eulerAngles = newRotation;
        car4.eulerAngles = newRotation;
        car5.eulerAngles = newRotation;

        newRotation = new Vector3(-30, 0, 0);
        map1.eulerAngles = newRotation;
        map2.eulerAngles = newRotation;
        map3.eulerAngles = newRotation;
    }

}
