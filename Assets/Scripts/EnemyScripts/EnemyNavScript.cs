using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public Transform player;
    public Transform diveBox;
    private NavMeshAgent enemy;
    private EnemyAttackRandomizer diveCheck;
    public static bool closeTheDistance = false;
    private EnemyHealth enemyHealth;

    //The bools below only matters for diving enemies
    public bool onGround = false;
    public bool midDive = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        diveBox = GameObject.FindWithTag("DiveBox").transform;
        enemyHealth = GetComponent<EnemyHealth>();
        diveCheck = GetComponent<EnemyAttackRandomizer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Enemy Nav Has Dived is equal to {onGround}");
        if (enemyHealth.isDead == true)
        {
            enemy.destination = enemy.transform.position;
        }
        else if (closeTheDistance && !onGround)
        {
            enemy.destination = player.position;
        }
        else if (onGround && !midDive)
        {
            enemy.destination = enemy.transform.position;
        }
        else if (midDive)
        {
            enemy.destination = enemy.destination = new Vector3(player.position.x, player.position.y, player.position.z + 2f);
        }
        else if (!closeTheDistance)
        {
            enemy.destination = enemy.transform.position;
        }


        if (EnemyAttackRandomizer.closeEnoughToAttack && !midDive && !onGround)
        {
        Vector3 playerPos = player.transform.position;
        Vector3 npcPos = gameObject.transform.position;
        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
        Quaternion rotation = Quaternion.LookRotation(delta);
        gameObject.transform.rotation = rotation;
        }
    }

    public void DiveLandedTrigger()
    {
        onGround = true;
        midDive = false;
        diveCheck.divingEnemy = false;
    }

    public void DiveFinishedTrigger() 
    {
        onGround = false;
    }

    public void DiveTargetTrigger()
    {
        midDive = true;
        Debug.Log("Successfully called dive trigger");
    }
}
