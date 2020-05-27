using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float intensityAmount = 1f;
    [SerializeField] float angleAmount = 70f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            other.GetComponentInChildren<FlashLightSystem>().restoreAngle(angleAmount);
            other.GetComponentInChildren<FlashLightSystem>().increaseIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
