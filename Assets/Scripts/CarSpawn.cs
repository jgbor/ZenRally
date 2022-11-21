using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpawn : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public Transform transform;

    private GameObject countDown;
    public AudioSource threeSound;
    public AudioSource twoSound;
    public AudioSource oneSound;
    public AudioSource goSound;

    // Start is called before the first frame update
    void Start()
    {
        GameObject car = null;
        if(MainMenuScript.CarNumber == 1)
        {
            car = Instantiate(car1) as GameObject;
        }
        if(MainMenuScript.CarNumber == 2)
        {
            car = Instantiate(car2) as GameObject;
        }
        if(MainMenuScript.CarNumber == 3)
        {
            car = Instantiate(car3) as GameObject;
        }
        if(MainMenuScript.CarNumber == 4)
        {
            car = Instantiate(car4) as GameObject;
        }

        if(car != null)
        {
            car.SetActive(true);
            car.transform.position = transform.position;
            car.transform.rotation = transform.rotation;
        }

        StartCoroutine(CountDownRoutine(car));
    }

    IEnumerator CountDownRoutine(GameObject car)
    {
        car.GetComponent<RCC_CarControllerV3>().enabled = false;
        
        countDown = GameObject.FindGameObjectWithTag("CntDown");
        countDown.GetComponent<Text>().text = "";

        yield return new WaitForSeconds(0.5f);
        countDown.GetComponent<Text>().text = "3";
        //threeSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "2";
        //twoSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        countDown.GetComponent<Text>().text = "1";
        //oneSound.Play();
        countDown.SetActive(true);

        yield return new WaitForSeconds(1f);
        countDown.SetActive(false);
        car.GetComponent<RCC_CarControllerV3>().enabled = true;
        countDown.GetComponent<Text>().text = "GO!";
        //goSound.Play();
        countDown.SetActive(true);
    }
}
