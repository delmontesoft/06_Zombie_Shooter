using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] TextMeshProUGUI healthText = null;

    private void Start()
    {
        healthText.text = "HEALTH: " + hitPoints.ToString();
    }

    public void TakeDamage(float damageTaken)
    {
        if (hitPoints > 0)
        {
            hitPoints = hitPoints - damageTaken;
            healthText.text = "HEALTH: " + hitPoints.ToString();
        }

        if (hitPoints <= 0)
        {
            healthText.text = "HEALTH: 0";
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
