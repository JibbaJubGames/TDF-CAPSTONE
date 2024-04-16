using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [Header("Detection Space")]
    [Range(1,10)]
    public float fightRadius;
    public LayerMask targetLayer;

    [Header("Music Swap")]
    public MusicFade musicController;
    //Only switch to true in inspector if this is the enemy detection script on Jerbulcha
    public bool isPlayer;
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

            musicController.BattleMusicFadeIn();
        }
        else
        {
            CombatInput.IsEnemyClose = false;
          
            musicController.IdleMusicFadeIn();
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.transform.position, fightRadius);
    }

}
