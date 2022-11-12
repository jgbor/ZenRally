using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public GameObject car1;
    public GameObject car2;
    public GameObject car3;
    public GameObject car4;
    public Transform transform;

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
    }
}
