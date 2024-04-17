using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavScript : MonoBehaviour
{
    public Transform player;
    public Transform diveBox;
    private NavMeshAgent enemy;
    public static bool closeTheDistance = false;

    //The bool below only matters for diving enemies
    public bool hasDived = true;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
        diveBox = GameObject.FindWithTag("DiveBox").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Enemy Nav Has Dived is equal to {hasDived}");
        if (closeTheDistance)
        {
            enemy.destination = player.position;
        }
        else if (hasDived && EnemyAttackRandomizer.closeEnoughToAttack)
        {
            enemy.destination = new Vector3(player.position.x, player.position.y, player.position.z + 2f);
        }
        else
        {
            enemy.destination = enemy.transform.position;
        }
    }
}
