using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{   
    [SerializeField] Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        
        healthSlider.maxValue = PlayerHealth.playerMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = PlayerHealth.playerHealth;
    }
}
