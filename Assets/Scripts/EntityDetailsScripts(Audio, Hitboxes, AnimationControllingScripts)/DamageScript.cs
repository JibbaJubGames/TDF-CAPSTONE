using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [Header("Damage Setup")]
    //In the inspector, write the tag that the player is meant to deal damage to
    public string enemyTag;

    //Not used in inspector
    private EnemyHealth enemyHealth;

    private void Start()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == enemyTag && PlayerHealth.midAttack)
        {
            enemyHealth = other.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.TakeDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemyHealth = null;
    }
}
