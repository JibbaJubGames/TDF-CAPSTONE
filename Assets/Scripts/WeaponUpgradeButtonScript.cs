using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeButtonScript : MonoBehaviour
{
    public WeaponUpgradeScript weaponDetails;
    public BlacksmithSubtitle blacksmithSubtitle;
    public WeaponUpgradeBoxClick weaponUpgradeBoxClick;
    public WeaponStatsHolder weaponStatsHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpgradeWeapon()
    {
        if (weaponDetails.weaponLevel == 1 && InventoryCount.godlySteelCount < weaponDetails.neededSteelOne)
        {
            blacksmithSubtitle.InsufficientMaterialsLine.Play();
            blacksmithSubtitle.LineEscapeClause(3);
        }
        else if (weaponDetails.weaponLevel == 1 && InventoryCount.godlySteelCount >= weaponDetails.neededSteelOne)
        {
            InventoryCount.godlySteelCount -= weaponDetails.neededSteelOne;
            blacksmithSubtitle.UpgradePurchaseLine.Play();
            blacksmithSubtitle.LineEscapeClause(4);
            weaponDetails.weaponLevel++;
            weaponUpgradeBoxClick.UpdateUpgradeInfo();
            weaponStatsHolder.attackBonus = weaponDetails.attackIncreaseOne;
            weaponStatsHolder.speedBonus = weaponDetails.speedIncreaseOne;
            weaponStatsHolder.healthBonus = weaponDetails.healthIncreaseOne;
            weaponStatsHolder.UpdateStatsText();
        }
        else if (weaponDetails.weaponLevel == 2 && InventoryCount.godlySteelCount < weaponDetails.neededSteelTwo)
        {
            blacksmithSubtitle.InsufficientMaterialsLine.Play();
            blacksmithSubtitle.LineEscapeClause(3);
        }
        else if (weaponDetails.weaponLevel == 2 && InventoryCount.godlySteelCount >= weaponDetails.neededSteelTwo)
        {
            InventoryCount.godlySteelCount -= weaponDetails.neededSteelTwo;
            blacksmithSubtitle.UpgradePurchaseLine.Play();
            blacksmithSubtitle.LineEscapeClause(4);
            weaponDetails.weaponLevel++;
            weaponUpgradeBoxClick.UpdateUpgradeInfo();
            weaponStatsHolder.attackBonus = weaponDetails.attackIncreaseTwo;
            weaponStatsHolder.speedBonus = weaponDetails.speedIncreaseTwo;
            weaponStatsHolder.healthBonus = weaponDetails.healthIncreaseTwo;
            weaponStatsHolder.UpdateStatsText();
        }
            
    }
}
