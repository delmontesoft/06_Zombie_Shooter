using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    [SerializeField] AmmoType ammoType = 0;
    [SerializeField] int ammoAmmount = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            FindObjectOfType<Ammo>().IncreaseCurrentAmmo(ammoType, ammoAmmount);
            Destroy(gameObject);
        }
    }
}
