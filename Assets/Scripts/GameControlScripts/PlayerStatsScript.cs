using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static float damageBonus;
    public static float healthBonus;
    public static float speedBonus;

    public static float damage = 1;
    public static float maxHealth = 20;
    public static float speed = 6;

    [Header("Double Attack Info")]
    public static float doubleAttackTimer;
    private static bool usedCrystal = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        doubleAttackTimer -= Time.deltaTime;
        AttackCrystal();
    }

    public static void AttackCrystal()
    {
        
        if (doubleAttackTimer==10)
        {
            damage = damage * 2.0f;
            usedCrystal = true;
            doubleAttackTimer = 9.99f;
        }

        if (doubleAttackTimer <= 0 && usedCrystal)
        {
            damage = damage / 2.0f;
            usedCrystal = false;
        }

        Debug.Log($"Currently dealing {damage} on each strike");
    }

    public static void UpdatePlayerStats()
    {
        damage = damage * 1f + damageBonus/10;
        maxHealth = maxHealth * 1f + healthBonus/10;
        speed = speed * 1f + speedBonus/10;
    }
}
