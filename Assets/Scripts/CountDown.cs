using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    private GameObject countDown;
    public AudioSource threeSound;
    public AudioSource twoSound;
    public AudioSource oneSound;
    public AudioSource goSound;


    void Start()
    {
        StartCoroutine(CountDownRoutine());        
    }

    IEnumerator CountDownRoutine() {
        GameObject.FindGameObjectWithTag("Player").GetComponent<RCC_CarControllerV3>().enabled = false;
        countDown = GameObject.FindGameObjectWithTag("CntDown");

        yield return new WaitForSeconds(0.5f);
        countDown.GetComponent<Text>().text = "3";
        //threeSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        //twoSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        //oneSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "GO!";
        //goSound.Play();
        countDown.SetActive(true);

        GameObject.FindGameObjectWithTag("Player").GetComponent<RCC_CarControllerV3>().enabled = true;
    }

}
