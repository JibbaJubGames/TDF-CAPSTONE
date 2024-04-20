using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombatRangeScript : MonoBehaviour
{
    [Header("Detection Space")]
    [Range(0, 5)]
    public float attackRadius;
    [Range(1, 15)]
    public float fightRadius;
    public LayerMask targetLayer;


    private Animator animCheck;
    // Start is called before the first frame update
    void Start()
    {
        animCheck = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAttackTime();
        CheckIfApproachTime();
    }

    private void CheckIfAttackTime()
    {
        if (Physics.CheckSphere(this.transform.position, attackRadius, targetLayer))
        {
            EnemyAttackRandomizer.closeEnoughToAttack = true;
            EnemyNavScript.closeTheDistance = false;
            animCheck.SetBool("CloseTheDistance", false);
        }
        else
        {
            EnemyAttackRandomizer.closeEnoughToAttack = false;
            EnemyNavScript.closeTheDistance = true;
        }
    }

    private void CheckIfApproachTime()
    {
        if (Physics.CheckSphere(this.transform.position, fightRadius, targetLayer) && !EnemyAttackRandomizer.closeEnoughToAttack)
        {
            EnemyNavScript.closeTheDistance = true;
            animCheck.SetBool("CloseTheDistance", true);
        }
        else
        {
            EnemyNavScript.closeTheDistance = false;
            animCheck.SetBool("CloseTheDistance", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,.5f);
        Gizmos.DrawSphere(this.transform.position, fightRadius);
        Gizmos.color = new Color (1f, 0f, 1f);
        Gizmos.DrawSphere(this.transform.position, attackRadius);
    }
}
