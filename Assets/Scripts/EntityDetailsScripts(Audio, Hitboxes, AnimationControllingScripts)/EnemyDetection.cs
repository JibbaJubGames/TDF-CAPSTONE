using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Detection Space")]
    public float fightRadius = 15;
    public LayerMask targetLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCheck();
    }

    private void EnemyCheck()
    {
        if (Physics.CheckSphere(this.transform.position, fightRadius, targetLayer))
        {
            Debug.Log("Hit Enemy");
            CombatInput.IsEnemyClose = true;
        }
        else
        {
            Debug.Log("No enemies here");
            CombatInput.IsEnemyClose = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, fightRadius);
    }

}
