using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isEnemyDead = false;

    public void TakeDamage(float damageTaken)
    {
        if (hitPoints >0)
        {
            BroadcastMessage("OnDamageTaken");
            hitPoints = hitPoints - damageTaken;
        }

        if (hitPoints <= 0 && !isEnemyDead)
        {
            StartDeathSequence();
        }
        
    }

    private void StartDeathSequence()
    {
        isEnemyDead = true;
        GetComponent<Animator>().SetTrigger("die");

        //Destroy(gameObject);
    }


    public bool IsEnemyDead()
    {
        return isEnemyDead;
    }
}
