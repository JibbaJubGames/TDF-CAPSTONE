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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DamageTimer();
    }

    private void DamageTimer()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer > 1f)
        {
            beenDamaged = false;
        }
    }

    public void TakeDamage()
    {
        if (!beenDamaged)
        {   
        beenDamaged = true;
        damageTimer = 0f;
        Debug.Log("Jerbulcha has been hit");
        animToTrigger.SetTrigger("TookDamage");
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
}
