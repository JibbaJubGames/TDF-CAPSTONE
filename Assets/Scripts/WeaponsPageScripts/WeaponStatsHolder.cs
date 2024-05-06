using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStatsHolder : MonoBehaviour
{
    public int attackBonus;
    public int healthBonus;
    public int speedBonus;

    public int upgradeLevel = 1;

    public TMP_Text statsInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateStatsText()
    {
        statsInfo.text =
                    $"Attack: {attackBonus} \n" +
                    $"\n" +
                    $"Speed: {speedBonus} \n" +
                    $"\n" +
                    $"Health: {healthBonus}";
    }
}
