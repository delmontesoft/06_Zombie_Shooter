using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera = null;
    [SerializeField] ParticleSystem muzzleFlashVFX = null;
    [SerializeField] GameObject bulletHitVFXPrefab = null;
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
        PlayMuzzleFlash();
        ProcessRayCast();
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
}
