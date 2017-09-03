using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour {

    public float lightTimeOn = 10f;
    public int yellowLightPct = 80;
    public GameObject blackScreen;

    float waitTime;
    bool isLightOn = true;
    GameObject[] redLights = new GameObject[0];
    GameObject[] greenLights = new GameObject[0];

    void Awake ()
    {
        if (blackScreen == null)
        {
            blackScreen = GameObject.FindGameObjectWithTag("Noir");
        }
        blackScreen.gameObject.SetActive(false);
        redLights = GameObject.FindGameObjectsWithTag("RedLight");
        greenLights = GameObject.FindGameObjectsWithTag("GreenLight");
        for (int i = 0; i < redLights.Length; i++)
        {
            redLights[i].gameObject.SetActive(false);
        }
    }

    void Update ()
    {
        waitTime += Time.deltaTime;
        if (isLightOn && waitTime > lightTimeOn)
        {
            ResetTimer();
            blackScreen.gameObject.SetActive(true);
            for (int i = 0; i < redLights.Length; i++)
            {
                for (int j = 0; j < greenLights.Length; j++)
                {
                    greenLights[j].gameObject.SetActive(false);
                    redLights[i].gameObject.SetActive(true);
                }
            }
            isLightOn = false;
        }
        else if (!isLightOn && waitTime > lightTimeOn)
        {
            ResetTimer();
            blackScreen.gameObject.SetActive(false);
            for (int i = 0; i < redLights.Length; i++)
            {
                for (int j = 0; j < greenLights.Length; j++)
                {
                    redLights[i].gameObject.SetActive(false);
                    greenLights[j].gameObject.SetActive(true);
                }
            }
            isLightOn = true;
        }
        else if (waitTime > (yellowLightPct * lightTimeOn) / 100)
        {
            for (int i = 0; i < redLights.Length; i++)
            {
                for (int j = 0; j < greenLights.Length; j++)
                {
                    if (!redLights[i].gameObject.active)
                    {
                        redLights[i].gameObject.SetActive(true);
                    }
                    if (!greenLights[j].gameObject.active)
                    {
                        greenLights[j].gameObject.SetActive(true);
                    }
                }
            }
        }
    }
    
    void ResetTimer ()
    {
        waitTime = 0;
        waitTime += Time.deltaTime;
    }
}
