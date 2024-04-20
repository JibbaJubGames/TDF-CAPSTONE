using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTackledScript : MonoBehaviour
{
    private static Animator tackleAnim;
    private PlayerHealth playerHealth;
    public bool beenTackledYet = false;
    public float tackleResetTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        tackleAnim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
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
        //Connect line below/this script to player health
        playerHealth.TakeDamageFromTackle();
    }
}
