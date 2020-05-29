using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float attackPower = 40f;

    private void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    public void AttackHitEvent()
    {
        if (!target) {
            return;
        }
        target.TakeDamage(attackPower);
        target.GetComponent<DisplayDamage>().ShowDamageImpact();
    }


}
