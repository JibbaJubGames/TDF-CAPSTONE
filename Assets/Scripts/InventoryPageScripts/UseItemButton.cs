using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class UseItemButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void UseItem()
    {
        if (SelectedItemUpdate.itemType != "Steel" && SelectedItemUpdate.itemType != "")

        if (SelectedItemUpdate.itemType == "Health") UseHealthCrystal();

        else if (SelectedItemUpdate.itemType == "Attack") UseAttackCrystal();

                
    }

    private static void UseAttackCrystal()
    {
        
        if (InventoryCount.attackCrystalCount > 0)
        {
            PlayerStatsScript.doubleAttackTimer = 10;
            InventoryCount.attackCrystalCount--;
            SelectedItemUpdate.chosenText.text = $"Attack Crystal ({InventoryCount.attackCrystalCount})";
        }   
    }

    public static void UseHealthCrystal()
    {
        if (InventoryCount.healthCrystalCount > 0 && PlayerHealth.playerHealth < PlayerHealth.playerMaxHealth)
        {
            PlayerHealth.playerHealth = PlayerHealth.playerHealth + PlayerHealth.playerMaxHealth / 10;
            InventoryCount.healthCrystalCount--;
            SelectedItemUpdate.chosenText.text = $"Health Crystal ({InventoryCount.healthCrystalCount})";
        }
    }
}

