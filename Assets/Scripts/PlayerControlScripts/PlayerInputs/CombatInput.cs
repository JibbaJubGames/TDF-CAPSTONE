using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInput : MonoBehaviour
{
    [Header("Animator Reference")]
    public Animator jerbulchaCombatAnim;

    [Header("Testing Purposes")]
    public bool IsEnemyClose;

    [Header("Attack Cooldowns")]
    public float attackCooldown = 0.5f;

    [Header("ComboCounts")]
    public bool HeavyComboOne;
    public bool HeavyComboTwo;
    public bool HeavyComboThree;

    public bool LightComboOne;
    public bool LightComboTwo;
    public bool LightComboThree;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        SetCombatIdle();

        ComboCheck();
    }

    private void ComboCheck()
    {
        //Step1: Check if right clicked this frame
        //Step2: Check if a combo is in progress
        //Step3: Move on to next combo move if yes
        //Step4: Reset combo counter if player didn't start combo with correct timing
        attackCooldown += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse1) && attackCooldown >= 0 && !HeavyComboOne)
        {
            jerbulchaCombatAnim.SetTrigger("HeavyAttackOne");
            HeavyComboOne = true;
            attackCooldown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && HeavyComboOne == true)
            {
                HeavyComboTwo = true;
                jerbulchaCombatAnim.SetTrigger("HeavyAttackTwo");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (attackCooldown >= 1 && HeavyComboTwo == true && HeavyComboThree == false)
            {
                HeavyComboThree = true;
                jerbulchaCombatAnim.SetTrigger("HeavyAttackThree");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown >= 0 && !LightComboOne)
        {
            jerbulchaCombatAnim.SetTrigger("LightAttackOne");
            LightComboOne = true;
            attackCooldown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && LightComboOne == true)
            {
                LightComboTwo = true;
                jerbulchaCombatAnim.SetTrigger("LightAttackTwo");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackCooldown >= 1 && LightComboTwo == true && LightComboThree == false)
            {
                LightComboThree = true;
                jerbulchaCombatAnim.SetTrigger("LightAttackThree");
            }
        }

        if (attackCooldown >= 2)
        {
         ResetComboCounter();
        }
        
    }

    private void ResetComboCounter()
    {
        HeavyComboOne = false;
        HeavyComboTwo = false;
        HeavyComboThree = false;
        
        LightComboOne = false;
        LightComboTwo = false;
        LightComboThree = false;
    }

    private void SetCombatIdle()
    {
        if (IsEnemyClose)
        {
            jerbulchaCombatAnim.SetBool("CombatTime", true);
        }
        else
        {
            jerbulchaCombatAnim.SetBool("CombatTime", false);
        }
    }
}
