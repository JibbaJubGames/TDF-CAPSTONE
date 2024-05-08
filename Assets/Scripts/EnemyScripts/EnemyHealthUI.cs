using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] Slider enemyHealthSlider;
    [SerializeField] EnemyHealth enemyHealth;
    [SerializeField] GameObject enemyCanvas;
    //[SerializeField] GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthSlider.maxValue = enemyHealth.GetEnemyHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealthSlider.value = enemyHealth.GetEnemyHealth();
        enemyCanvas.transform.LookAt(Camera.main.transform);
    }
}
