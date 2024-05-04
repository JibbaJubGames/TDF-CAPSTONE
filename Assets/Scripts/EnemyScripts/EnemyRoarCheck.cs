using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoarCheck : MonoBehaviour
{
    [Header("Scream Info")]
    public AudioSource ThisOffSpringsScream;
    public float ScreamRadius;
    public LayerMask TargetLayer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] listeningEnemies = Physics.OverlapSphere(this.transform.position, ScreamRadius, TargetLayer);
        {
            foreach (var hitCollider in listeningEnemies) 
            {
                if (this.ThisOffSpringsScream.isPlaying)
                {
                    hitCollider.gameObject.GetComponentInParent<EnemyNavScript>().closeTheDistance = true;
                    hitCollider.gameObject.GetComponentInParent<EnemyCombatRangeScript>().hasRoared = true;
                }
            }
        }
    }
}
