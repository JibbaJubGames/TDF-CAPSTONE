using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public bool beenDamaged = false;
    private float damageTimer = 0f;
    [Header("Animator for getting damaged visual")]
    public Animator animToTrigger;


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

        if (heavyComboEnd) { Debug.Log("HEAVY FINISH ATTACK"); }
        Debug.Log($"Mid attack is a {midAttack} statement");
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
        Debug.Log("Jerbulcha has been hit");
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
}
