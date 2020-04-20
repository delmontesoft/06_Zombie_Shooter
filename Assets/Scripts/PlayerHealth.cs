using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damageTaken)
    {
        if (hitPoints > 0)
        {
            hitPoints = hitPoints - damageTaken;
        }

        if (hitPoints <= 0)
        { 
            print("Player killed!");
            //TODO start player death sequence
        }
    }
}
