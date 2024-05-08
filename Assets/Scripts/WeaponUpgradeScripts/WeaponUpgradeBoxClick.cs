using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeBoxClick : MonoBehaviour
{
    public Image thisItem;
    public string thisItemName;
    public string thisItemDescription;
    public WeaponUpgradeInfoScript upgradeInfo;
    public WeaponUpgradeScript weaponDetails;
    public WeaponUpgradeButtonScript upgradeButton;
    public WeaponStatsHolder weaponStatsHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateUpgradeInfo()
    {
        upgradeButton.weaponStatsHolder = weaponStatsHolder;
        upgradeButton.weaponDetails = weaponDetails;
        upgradeButton.weaponUpgradeBoxClick = this;
        thisItemDescription = weaponDetails.weaponLevel.ToString();
        upgradeInfo.chosenWeaponLevel.text = $"({thisItemDescription}/3)";
        UpgradeStatChanges();
        UpgradeMaterialsList();

        upgradeInfo.chosenWeapon.sprite = thisItem.sprite;
        upgradeInfo.chosenWeaponName.text = thisItemName;
    }

    private void UpgradeMaterialsList()
    {
        if (weaponDetails.weaponLevel == 1)
        {
            upgradeInfo.chosenWeaponMats.text = $"GODLY STEEL: {InventoryCount.godlySteelCount} / {weaponDetails.neededSteelOne} \n" +
                $"\n" +
                "P.HOLDER: {OWNED} / {NEEDED} \n" +
                $"\n" +
                "P.HOLDER: {OWNED} / {NEEDED}";
        }
        else if (weaponDetails.weaponLevel == 2)
        {
            upgradeInfo.chosenWeaponMats.text = $"GODLY STEEL: {InventoryCount.godlySteelCount} / {weaponDetails.neededSteelTwo} \n" +
                $"\n" +
                "P.HOLDER: {OWNED} / {NEEDED} \n" +
                $"\n" +
                "P.HOLDER: {OWNED} / {NEEDED}";
        }
    }

    private void UpgradeStatChanges()
    {
        if (weaponDetails.weaponLevel == 1)
        {
            upgradeInfo.chosenWeaponStatChanges.text = $"New Attack: {weaponDetails.attackIncreaseOne} \n" +
                        $"\n" +
                        $"New Speed: {weaponDetails.speedIncreaseOne} \n" +
                        $"\n" +
                        $"New Health: {weaponDetails.healthIncreaseOne}";
        }
        else if (weaponDetails.weaponLevel == 2)
        {
            upgradeInfo.chosenWeaponStatChanges.text = $"Attack: {weaponDetails.attackIncreaseTwo} \n" +
                        $"\n" +
                        $"Speed: {weaponDetails.speedIncreaseTwo} \n" +
                        $"\n" +
                        $"Health: {weaponDetails.healthIncreaseTwo}";
        }
        else if (weaponDetails.weaponLevel == 3)
        {
            upgradeInfo.chosenWeaponStatChanges.text = "FULLY UPGRADED";
        }
    }
}
