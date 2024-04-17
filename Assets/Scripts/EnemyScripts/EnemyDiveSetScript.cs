using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDiveSetScript : MonoBehaviour
{
    public int diver;
    private bool setEnemyType = false;
    private EnemyAttackRandomizer attackRandomizer;
    private EnemyNavScript navScript;
    // Start is called before the first frame update
    void Start()
    {
        diver = Random.Range(1, 3);
        attackRandomizer = this.GetComponent<EnemyAttackRandomizer>();
        navScript = this.GetComponent<EnemyNavScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (diver == 1 && !setEnemyType) 
        {
        attackRandomizer.divingEnemy = true;
        setEnemyType = true;
        navScript.hasDived = false;
        }
        else if (diver == 2 && !setEnemyType)
        {
        attackRandomizer.divingEnemy = false;
        setEnemyType = true;
        }
    }
}
