using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingScript : MonoBehaviour
{
    public int totalMin;
    public int totalSec;
    public float totalMillisec;

    private int lapMin;
    private int lapSec;
    private float lapMillisec;

    private int bestMin;
    private int bestSec;
    private float bestMillisec;

    private GameObject minText;
    private GameObject secText;
    private GameObject milliText;

    private GameObject bestMinText;
    private GameObject bestSecText;
    private GameObject bestMilliText;

    public bool countTime;

    private void Start()
    {
        countTime = false;
    }
    
    void Update()
    {
        if (countTime)
        {
            totalMillisec += Time.deltaTime * 1000;
            lapMillisec += Time.deltaTime * 1000;
            if (totalMillisec >= 1000)
            {
                totalMillisec = 0;
                lapMillisec = 0;
                totalSec++;
                lapSec++;
            }
            if (totalSec >= 60)
            {
                totalSec = 0;
                lapSec= 0;
                totalMin++;
                lapMin++;
            }
            if (totalMillisec < 10) { 
                milliText.GetComponent<Text>().text= "00" + totalMillisec.ToString("F0");
            }
            else if (totalMillisec < 100) {
                milliText.GetComponent<Text>().text = "0" + totalMillisec.ToString("F0");
            }
            else
            {
                milliText.GetComponent<Text>().text = totalMillisec.ToString("F0");
            }
            if (totalSec < 10)
            {
                secText.GetComponent<Text>().text = $"0{totalSec}.";
            }
            else
            {
                secText.GetComponent<Text>().text = $"{totalSec}.";
            }
            minText.GetComponent<Text>().text = $"{totalMin}:";          
        }
    }

    public void EndLap()
    {
        if ((lapMin * 60 + lapSec) * 1000 + lapMillisec < (bestMin * 60 + bestSec) * 1000 + bestMillisec)
        {
            bestMin = lapMin;
            bestSec = lapSec;
            bestMillisec = lapMillisec;
            if (bestMillisec < 10)
            {
                bestMilliText.GetComponent<Text>().text = "00" + bestMillisec.ToString("F0");
            }
            else if (bestMillisec < 100)
            {
                bestMilliText.GetComponent<Text>().text = "0" + bestMillisec.ToString("F0");
            }
            else
            {
                bestMilliText.GetComponent<Text>().text = bestMillisec.ToString("F0");
            }
            if (bestSec < 10)
            {
                bestSecText.GetComponent<Text>().text = $"0{bestSec}.";
            }
            else
            {
                bestSecText.GetComponent<Text>().text = $"{bestSec}.";
            }
            bestMinText.GetComponent<Text>().text = $"{bestMin}:";
           
        }
        lapMin = 0;
        lapSec = 0;
        lapMillisec = 0;
    }

    public void StartCounting()
    {
        countTime = true;
        totalMin = 0;
        totalSec = 0;
        totalMillisec = 0;
        minText = GameObject.Find("Minutes");
        secText = GameObject.Find("Seconds");
        milliText = GameObject.Find("Millisecs");
        bestMinText = GameObject.Find("BestMinutes");
        bestSecText = GameObject.Find("BestSeconds");
        bestMilliText = GameObject.Find("BestMillisecs");
        bestMin = 1000;
        bestSec = 1000;
        bestMillisec = 1000;
    }
}
