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

    public bool hasRoared = false;
    private bool roarStated = false;
    private GameObject player;
    private EnemyNavScript myNavScript;
    private EnemyAttackRandomizer myAttackScript;
    // Start is called before the first frame update
    void Start()
    {
        animCheck = GetComponent<Animator>();
        player = GameObject.FindWithTag("Jerbulcha");
        myNavScript = GetComponent<EnemyNavScript>();
        myAttackScript = GetComponent<EnemyAttackRandomizer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfAttackTime();
        CheckIfApproachTime();
    }

    public void RoarSwitch()
    {
        if (!hasRoared)
        {
            hasRoared = true;
        }
    }

    private void CheckIfAttackTime()
    {
        if (Physics.CheckSphere(this.transform.position, attackRadius, targetLayer))
        {
            myAttackScript.closeEnoughToAttack = true;
            myNavScript.closeTheDistance = false;
            animCheck.SetBool("CloseTheDistance", false);
        }
        else
        {
            myAttackScript.closeEnoughToAttack = false;
            myNavScript.closeTheDistance = true;
        }
    }

    private void CheckIfApproachTime()
    {
        if (Physics.CheckSphere(this.transform.position, fightRadius, targetLayer) && !hasRoared && !roarStated)
        {
            roarStated = true;
            Vector3 playerPos = player.transform.position;
            Vector3 npcPos = gameObject.transform.position;
            Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
            Quaternion rotation = Quaternion.LookRotation(delta);
            gameObject.transform.rotation = rotation;
            animCheck.SetTrigger("SpottedPlayer");
        }
        if (Physics.CheckSphere(this.transform.position, fightRadius, targetLayer) && !myAttackScript.closeEnoughToAttack && hasRoared)
        {
            myNavScript.closeTheDistance = true;
            animCheck.SetBool("CloseTheDistance", true);
        }
        else
        {
            myNavScript.closeTheDistance = false;
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
