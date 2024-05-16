using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public PlayerDeath deadJerb;
    public bool beenDamaged = false;
    private float damageTimer = 0f;
    [Header("Animator for getting damaged visual")]
    public Animator animToTrigger;

    static public float playerMaxHealth = PlayerStatsScript.maxHealth;
    static public float playerHealth = playerMaxHealth;

    static public bool midAttack = false;
    static public bool heavyComboEnd = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DamageTimer();

        playerMaxHealth = PlayerStatsScript.maxHealth;
        EnsureHealthEqualOrLessMax();

        if (playerHealth <= 0)
        {
            animToTrigger.SetBool("hasDied", true);
            deadJerb.PlayerHasDied();
        }

        if (animToTrigger.GetBool("CombatTime") == false) 
        {
            midAttack = false;
        }

        if (midAttack == true && Input.GetAxis("Horizontal") != 0 || midAttack == true && Input.GetAxis("Vertical") != 0)
        {
            Debug.Log("Trying to cancel attack");
            if (LockOnSystem.lockedOn == true)
            {
                animToTrigger.Play("JERBULCHA_FIGHTIDLE(LockedOn)");
            } 
            else
            {
                animToTrigger.Play("JERBULCHA_FIGHTIDLE");
            }
            midAttack = false;
            animToTrigger.SetBool("HeavyAttackOne", false);
            animToTrigger.SetBool("HeavyAttackTwo", false);
            animToTrigger.SetBool("HeavyAttackThree", false);
            animToTrigger.SetBool("LightAttackOne", false);
            animToTrigger.SetBool("LightAttackTwo", false);
            animToTrigger.SetBool("LightAttackThree", false);
            Debug.Log($"Midattack is equal to {midAttack}");
        }
    }

    private static void EnsureHealthEqualOrLessMax()
    {
        if (playerHealth > playerMaxHealth)
        {
            playerHealth = playerMaxHealth;
        }
    }

    private void DamageTimer()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer > 2f)
        {
            beenDamaged = false;
        }
    }

    public void TakeDamage()
    {
        if (!beenDamaged)
        {
        midAttack = false;
        beenDamaged = true;
        damageTimer = 0f;
            playerHealth--;
        Debug.Log($"Jerbulcha has been hit! {playerHealth} health remaining!");
        animToTrigger.SetTrigger("TookDamage");
            ResetAttacks();

        }
    }
    public void TakeDamageFromTackle()
    {
        if (!beenDamaged)
        {   
        midAttack = false;
        beenDamaged = true;
        damageTimer = 0f;
            playerHealth-= 3;
        Debug.Log("Jerbulcha has been tackled");
        }
    }

    public void AttackStateSwap(string attacking)
    {
        if (attacking == "Yes")
        {
            midAttack = true;
        }
        if (attacking == "No")
        {
            midAttack = false;
        }
    }

    public void HeavyComboSwap(string HeavyCombo)
    {
        if (HeavyCombo == "Yes")
        {
            heavyComboEnd = true;
        }
        if (HeavyCombo == "No")
        {
            heavyComboEnd = false;
        }
    }

    private void ResetAttacks()
    {
        animToTrigger.SetBool("HeavyAttackOne", false);
        animToTrigger.SetBool("HeavyAttackTwo", false);
        animToTrigger.SetBool("HeavyAttackThree", false);
        animToTrigger.SetBool("LightAttackOne", false);
        animToTrigger.SetBool("LightAttackTwo", false);
        animToTrigger.SetBool("LightAttackThree", false);
    }

    public void ResetHealth()
    {
        playerHealth = playerMaxHealth;
    }
}
