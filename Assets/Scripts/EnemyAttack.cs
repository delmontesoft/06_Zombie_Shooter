using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float attackPower = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AttackHitEvent()
    {
        if (!target) return;
        print("Raaarr! Te estoy atacando!");
    }
}
