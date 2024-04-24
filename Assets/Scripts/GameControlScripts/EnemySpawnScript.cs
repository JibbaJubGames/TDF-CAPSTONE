using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    [Header("Enemy spawn setup")]
    public Transform[] spawnPoints;
    private int enemyCount = 0;
    public GameObject offspringPrefab;

    private bool beginSpawn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beginSpawn)
        {
            Debug.Log("Spawning enemies");
            if (enemyCount == spawnPoints.Length) { Object.Destroy(this); }
            else
            {
                offspringPrefab = Instantiate(offspringPrefab, spawnPoints[enemyCount]);
                enemyCount++;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
        beginSpawn = true;  
        }
    }
}
