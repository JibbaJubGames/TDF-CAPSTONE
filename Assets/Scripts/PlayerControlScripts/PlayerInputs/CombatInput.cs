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


    [SerializeField] Transform cam;

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
        if (Input.GetButtonDown("HeavyAttack") && attackCooldown >= 0 && !HeavyComboOne && IsEnemyClose && !PauseMenuScript.paused)
        {
            animToUse.SetTrigger("HeavyAttackOne");
            HeavyComboOne = true;
            attackCooldown = 0;
            LookAwayFromCam();
        }
        if (Input.GetButtonDown("HeavyAttack"))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && HeavyComboOne == true)
            {
                HeavyComboTwo = true;
                animToUse.SetTrigger("HeavyAttackTwo");
                LookAwayFromCam();
            }
        }
        if (Input.GetButtonDown("HeavyAttack"))
        {
            if (attackCooldown >= 1 && HeavyComboTwo == true && HeavyComboThree == false)
            {
                HeavyComboThree = true;
                animToUse.SetTrigger("HeavyAttackThree");
                LookAwayFromCam();
            }
        }
        
        if (Input.GetButtonDown("LightAttack") && attackCooldown >= 0 && !LightComboOne && IsEnemyClose && !PauseMenuScript.paused)
        {
            animToUse.SetTrigger("LightAttackOne");
            LightComboOne = true;
            attackCooldown = 0;
            LookAwayFromCam();
        }
        if (Input.GetButtonDown("LightAttack"))
        {
            if (attackCooldown >= .5 && attackCooldown <= .95f && LightComboOne == true)
            {
                LightComboTwo = true;
                animToUse.SetTrigger("LightAttackTwo");
                LookAwayFromCam();
            }
        }
        if (Input.GetButtonDown("LightAttack"))
        {
            if (attackCooldown >= 1 && LightComboTwo == true && LightComboThree == false)
            {
                LightComboThree = true;
                animToUse.SetTrigger("LightAttackThree");
                LookAwayFromCam();
            }
        }

        if (attackCooldown >= 2)
        {
         ResetComboCounter();
        }
        
    }

    private void LookAwayFromCam()
    {   
      transform.rotation = cam.transform.rotation;
     
     transform.eulerAngles = new Vector3
    (     
     transform.eulerAngles.x - transform.eulerAngles.x,
     transform.eulerAngles.y,
     transform.eulerAngles.z - transform.eulerAngles.z
     );
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
        if (MusicFade.enemyCount >= 1)
        {
            IsEnemyClose = true;
            animToUse.SetBool("CombatTime", true);
            musicSwap.BattleMusicFadeIn();
        }
        else
        {
            IsEnemyClose = false;
            animToUse.SetBool("CombatTime", false);
            musicSwap.IdleMusicFadeIn();
        }
    }
}
