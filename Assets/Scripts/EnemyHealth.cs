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
            hitPoints = hitPoints - damageTaken;
        }
        else
        {
            //TODO start enemy death sequence
            print("Enemy died!");
            Destroy(gameObject);
        }
        
    }

}
