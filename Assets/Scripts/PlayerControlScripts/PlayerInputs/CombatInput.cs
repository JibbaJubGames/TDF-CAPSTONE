using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatInput : MonoBehaviour
{
    //ATTACH THIS SCRIPT TO PLAYABLE CHARACTER MODEL

    [Header("Animator Reference")]
    public Animator animToUse;

    [Header("Trigger Fight Mode")]
    public static bool IsEnemyClose;

    [Header("Attack Cooldowns")]
    public float attackCooldown = 0.5f;

    [Header("ComboCounts")]
    public bool HeavyComboOne;
    public bool HeavyComboTwo;
    public bool HeavyComboThree;

    public bool LightComboOne;
    public bool LightComboTwo;
    public bool LightComboThree;

    [Header("Audio Controller Holder")]
    public AudioSelector audioControl;

    [Header("Music Swap")]
    public MusicFade musicSwap;

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
        if (Input.GetKeyDown(KeyCode.Mouse1) && attackCooldown >= 0 && !HeavyComboOne && IsEnemyClose)
        {
            animToUse.SetTrigger("HeavyAttackOne");
            HeavyComboOne = true;
            attackCooldown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && HeavyComboOne == true)
            {
                HeavyComboTwo = true;
                animToUse.SetTrigger("HeavyAttackTwo");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (attackCooldown >= 1 && HeavyComboTwo == true && HeavyComboThree == false)
            {
                HeavyComboThree = true;
                animToUse.SetTrigger("HeavyAttackThree");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown >= 0 && !LightComboOne && IsEnemyClose)
        {
            animToUse.SetTrigger("LightAttackOne");
            LightComboOne = true;
            attackCooldown = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && LightComboOne == true)
            {
                LightComboTwo = true;
                animToUse.SetTrigger("LightAttackTwo");
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (attackCooldown >= 1 && LightComboTwo == true && LightComboThree == false)
            {
                LightComboThree = true;
                animToUse.SetTrigger("LightAttackThree");
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
            animToUse.SetBool("CombatTime", true);
            musicSwap.BattleMusicFadeIn();
        }
        else
        {
            animToUse.SetBool("CombatTime", false);
            musicSwap.IdleMusicFadeIn();
        }
    }
}
