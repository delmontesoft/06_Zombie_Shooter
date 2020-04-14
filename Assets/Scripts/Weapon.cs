using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPcamera;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float weaponDamage = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPcamera.transform.position, FPcamera.transform.forward, out hit, weaponRange))
        {
            //TODO add some hit effect

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (!target) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }
}
