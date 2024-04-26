using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LockOnSystem : MonoBehaviour
{
    public bool lockedOn;
    public int lockedTarget = 0;
    public float lockTimer;
    public int enemyCount;
    [Header("TargetArrow")]
    public GameObject targetArrow;
    public int lockonRadius;
    public LayerMask TargetLayer;
    public Collider[] enemies;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lockTimer += Time.deltaTime;
        enemies = Physics.OverlapSphere(this.transform.position, lockonRadius, TargetLayer);
        enemyCount = enemies.Length - 1;
        ArrowOffAtDistance();
        Debug.Log("Found " + enemies.Length + " enemies");
        targetArrow.transform.position = new Vector3(enemies[lockedTarget].gameObject.transform.position.x, enemies[lockedTarget].gameObject.transform.position.y + 0.5f, enemies[lockedTarget].gameObject.transform.position.z);
        

        TriggerLock();
        PreviousTarget(enemies);
        NextTarget(enemies);
        AvoidOutsideOfBoundsError();
        FaceTarget();
    }

    private void AvoidOutsideOfBoundsError()
    {
        if (lockedTarget > enemyCount)
        {
            lockedTarget = enemyCount;
        }
    }

    private void ArrowOffAtDistance()
    {
        if (enemies.Length == 0)
        {
            Debug.Log("No more enemies");
            targetArrow.SetActive(false);
            lockedOn = false;
            lockedTarget = 0;
        }
    }

    private void FaceTarget()
    {
        if (lockedOn)
        {
            Vector3 playerPos = enemies[lockedTarget].transform.position;
            Vector3 npcPos = this.transform.position;
            Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);
            Quaternion rotation = Quaternion.LookRotation(delta);
            this.transform.rotation = rotation;
        }
    }

    private void NextTarget(Collider[] enemies)
    {
        if (lockedOn && Input.GetKeyDown(KeyCode.E))
        {
            if (lockedTarget == enemyCount)
            {
                Debug.Log("Max target reached, cycling through");
                lockedTarget = 0;
            }
            else
            {
                lockedTarget++;
            }
        }
    }

    private void PreviousTarget(Collider[] enemies)
    {
        if (lockedOn && Input.GetKeyDown(KeyCode.Q))
        {
            if (lockedTarget == 0)
            {
                Debug.Log("Min target reached, cycling through");
                lockedTarget = enemies.Length - 1;
            }
            else
            {
                lockedTarget--;
            }
        }
    }

    private void TriggerLock()
    {
        
        if (Input.GetKeyUp(KeyCode.Tab) && lockTimer > 1f)
        {
            lockTimer = 0f;
            lockedOn = true;
            Debug.Log("Time to lock in");
            targetArrow.SetActive(true);    
        }
        if (Input.GetKeyDown(KeyCode.Tab) && lockedOn && lockTimer > 1f )
        {
            lockTimer = 0f;
            targetArrow.SetActive(false);
            lockedOn = false;
            lockedTarget = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, lockonRadius);
    }
}
