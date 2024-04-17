using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTackledScript : MonoBehaviour
{
    private static Animator tackleAnim;
    private static PlayerHealth playerHealth;
    public bool beenTackledYet = false;
    public float tackleResetTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        tackleAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tackleResetTimer += Time.deltaTime;
        if (tackleResetTimer > 6f) 
        {
            beenTackledYet = false;
        }
    }

    public void GetTackled()
    {
        tackleResetTimer = 0f;
        beenTackledYet = true;
        tackleAnim.SetTrigger("HitByDive");
        playerHealth.TakeDamage();
    }
}
