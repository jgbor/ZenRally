using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScript : MonoBehaviour
{
    public GameObject FinishMenu;

    public void FinishGame()
    {
        GameObject.Find("Timer").GetComponent<TimingScript>().countTime = false;
        FinishMenu.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponentInParent<RCC_CarControllerV3>().canControl = false;
    }
}
