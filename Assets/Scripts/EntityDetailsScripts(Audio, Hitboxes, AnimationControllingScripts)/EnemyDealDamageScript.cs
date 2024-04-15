using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamageScript : MonoBehaviour
{
    [Header("Attack Set Up")]
    public bool isAttacking = false;
    public string playerTag;
    private PlayerHealth playerHealth;

    private void Update()
    {
        //isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == playerTag && isAttacking)
        {
            Debug.Log("Attacking Player");
            playerHealth = other.gameObject.GetComponentInParent<PlayerHealth>();
            playerHealth.TakeDamage();
        }
    }
}
