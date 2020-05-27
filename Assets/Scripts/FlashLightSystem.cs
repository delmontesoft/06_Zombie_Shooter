using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float intensityDecay = 0.1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 30f;

    Light myFlashlight;
    float maximumIntensity;

    private void Start()
    {
        myFlashlight = GetComponent<Light>();
        maximumIntensity = myFlashlight.intensity;
    }

    public void increaseIntensity(float intensityAmount)
    {
        if ((myFlashlight.intensity + intensityAmount) > maximumIntensity)
        {
            myFlashlight.intensity = maximumIntensity;
        }
        else
        {
            myFlashlight.intensity += intensityAmount;
        }
    }

    public void restoreAngle(float angleAmount)
    {
        myFlashlight.spotAngle = angleAmount;
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myFlashlight.spotAngle > minimumAngle)
        {
            myFlashlight.spotAngle -= angleDecay * Time.deltaTime;
        }
    }

    private void DecreaseLightIntensity()
    {
        myFlashlight.intensity -= intensityDecay * Time.deltaTime;
    }
}
