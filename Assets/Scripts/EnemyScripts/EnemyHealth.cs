using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool beenDamaged = false;
    private float damageTimer = 0f;
    private Animator enemyAnim;
    private int enemyHealth = 15;

    private EnemyAttackRandomizer attackCheck;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        attackCheck = GetComponent<EnemyAttackRandomizer>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        DamageTimer();

        if (enemyHealth <= 0)
        {
            EnemyDeath();
        }
    }

    private void DamageTimer()
    {
        damageTimer += Time.deltaTime;
        if (damageTimer > 1.5f)
        {
            beenDamaged = false;
        }
    }

    public void TakeDamage()
    {
        if (!beenDamaged)
        {
            attackCheck.isAttacking = false;
            beenDamaged = true;
            damageTimer = 0f;
            enemyAnim.SetTrigger("SmallHit");
            enemyHealth--;
            Debug.Log($"Enemy has {enemyHealth} health left");
        }
    }

    public void TakeBigDamage()
    {
        if (!beenDamaged)
        {
            attackCheck.isAttacking = false;
            beenDamaged = true;
            damageTimer = 0f;
            enemyAnim.SetTrigger("BigHit");
            enemyHealth -= 3;
            Debug.Log($"Enemy has {enemyHealth} health left and took BIG DAMAGE");
        }
    }

    public void EnemyDeath()
    {
        enemyAnim.SetTrigger("HasDied");
        if (!isDead) MusicFade.enemyCount--;
        isDead = true;
        
        this.gameObject.transform.position = 
        new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z-1 * Time.deltaTime);
        
        Destroy(this.gameObject, 3f);
    }
}
