using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRandomizer : MonoBehaviour
{
    [SerializeField] public Animator enemyAnim;
    private EnemyNavScript navScript;
    public int attackNumber;
    public string[] enemyAttacks;
    float timer = 0f;
    public bool closeEnoughToAttack = false;
    public bool divingEnemy = false;

    //Bool below only matters for diving enemies
    public bool hasDived = false;

    public bool isAttacking = false;
    
    // Start is called before the first frame update
    void Start()
    {
        navScript = GetComponent<EnemyNavScript>();
        enemyAttacks = new string[5];
        enemyAttacks[0] = ("SwordArmStab");
        enemyAttacks[1] = ("SwordArmSlash");
        enemyAttacks[2] = ("SwordArmDoubleStrike");
        enemyAttacks[3] = ("ClawArmSlash");
        enemyAttacks[4] = ("KickAttack");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Diving enemy is equal to {divingEnemy}");
        if (closeEnoughToAttack) timer += Time.deltaTime;
        DiveCheck();
        RandomAttack();
    }

    private void DiveCheck()
    {
        if (divingEnemy && closeEnoughToAttack && !hasDived)
        {
            enemyAnim.SetTrigger("DiveAttack");
            hasDived = true;
            enemyAnim.SetTrigger("DiveComplete");
        }
    }

    private void RandomAttack()
    {
        if (timer > 2f && closeEnoughToAttack && !divingEnemy)
        {
            attackNumber = Random.Range(0, 5);
            enemyAnim.SetTrigger(enemyAttacks[attackNumber]);
            Debug.Log($"{enemyAttacks[attackNumber]} is up next!");
            timer = 0;
        }
    }

    public void AttackStateSwap(string attacking)
    {
        if (attacking == "Yes")
        {
            isAttacking = true;
        }
        if (attacking == "No")
        {
            isAttacking = false;
        }
    }
}
