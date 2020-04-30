using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageTaken)
    {
        if (hitPoints >0)
        {
            BroadcastMessage("OnDamageTaken");
            hitPoints = hitPoints - damageTaken;
        }

        if (hitPoints <= 0)
        {
            //TODO start enemy death sequence
            Destroy(gameObject);
        }
        
    }

}
