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
    private EnemyNavScript diveEnemyCheck;

    //Below bool only matters for diving enemies
    public bool hitByDive = false;
    public GetTackledScript tackleScript;

    private void Start()
    {
        diveEnemyCheck = this.GetComponent<EnemyNavScript>();
        tackleScript = GameObject.FindWithTag("Jerbulcha").GetComponent<GetTackledScript>();
    }
    private void Update()
    {
        //isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {

        
        if (other.gameObject.tag == playerTag && isAttacking)
        {
            Debug.Log("Attacking Player");
            playerHealth = other.gameObject.GetComponentInParent<PlayerHealth>();
            playerHealth.TakeDamage();
        }
        
        else if (other.gameObject.tag == playerTag && diveEnemyCheck.hasDived)
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
