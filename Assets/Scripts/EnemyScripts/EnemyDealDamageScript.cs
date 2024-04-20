using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDealDamageScript : MonoBehaviour
{
    [Header("Attack Set Up")]
    public bool isAttacking = false;
    public string playerTag;
    private PlayerHealth playerHealth;

    //Used for dive enemy check
    private EnemyAttackRandomizer diveEnemyCheck;
    EnemyNavScript navScript;

    //Below bool only matters for diving enemies
    public bool hitByDive = false;
    public GetTackledScript tackleScript;

    private void Start()
    {
        navScript = this.GetComponentInParent<EnemyNavScript>();
        diveEnemyCheck = this.GetComponentInParent<EnemyAttackRandomizer>();
        tackleScript = GameObject.FindWithTag("Jerbulcha").GetComponent<GetTackledScript>();
        playerHealth = GameObject.FindWithTag("Jerbulcha").GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        //isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == playerTag && diveEnemyCheck.isAttacking)
        {
            Debug.Log("Attacking Player");
            playerHealth.TakeDamage();
        }
        if (other.gameObject.tag == playerTag && diveEnemyCheck.divingEnemy && navScript.midDive)
        {
            if (!tackleScript.beenTackledYet)
            {
                tackleScript.tackleResetTimer = 0f;
                Debug.Log("Tackling Player");
                tackleScript.GetTackled();
            }
            else return;
        }
        if (other.gameObject.tag == playerTag)
        {   
            Debug.Log("Touched player");
        }
    }

    
}
