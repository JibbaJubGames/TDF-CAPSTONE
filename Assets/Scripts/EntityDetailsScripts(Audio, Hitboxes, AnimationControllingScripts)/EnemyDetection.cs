using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Offspring")
        {
            MusicFade.enemyCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Offspring")
        {
            MusicFade.enemyCount--;
        }
    }

}
