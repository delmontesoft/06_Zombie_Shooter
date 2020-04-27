using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] ParticleSystem muzzleFlashVFX = null;
    [SerializeField] GameObject bulletHitVFXPrefab = null;
    [SerializeField] Ammo ammoSlot = null;
    [SerializeField] float weaponRange = 100f;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] float weaponZoomRange = 40f;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }

        if (Input.GetButtonDown("Zoom"))
        {
            ToggleZoom();
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo() >0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo();
        }

        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, weaponRange))
        {
            PlayBulletHitFX(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (!target) return;
            target.TakeDamage(weaponDamage);
        }
        else
        {
            return;
        }
    }

    private void PlayBulletHitFX(RaycastHit hit)
    {
        GameObject hitFXInstance = Instantiate(bulletHitVFXPrefab, hit.point, Quaternion.LookRotation(hit.normal), transform);
        Destroy(hitFXInstance, 0.1f);
    }

    private void ToggleZoom()
    {
        FindObjectOfType<WeaponZoom>().ToggleZoom(weaponZoomRange);
    }
}
