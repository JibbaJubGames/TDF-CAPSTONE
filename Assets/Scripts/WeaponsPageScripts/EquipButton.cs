using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    public int pastEquippableSpeed;
    public int pastEquippableAttack;
    public int pastEquippableHealth;
    public WeaponStatsHolder equippableStats;
    public string equippableName;

    public Button unequipButton;
    public Button equipButton;
    public bool weaponEquipped = false;

    public GameObject leftTwinBlade;
    public GameObject rightTwinBlade;
    public GameObject leftGBB;
    public GameObject rightGBB;
    public GameObject leftClaw;
    public GameObject rightClaw;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateStats()
    {
        PlayerStatsScript.speedBonus += equippableStats.speedBonus;
        PlayerStatsScript.damageBonus += equippableStats.attackBonus;
        PlayerStatsScript.healthBonus += equippableStats.healthBonus;
        equipButton.interactable = false;
        unequipButton.interactable = true;
        weaponEquipped = true;


        pastEquippableSpeed = equippableStats.speedBonus;
        pastEquippableAttack = equippableStats.attackBonus;
        pastEquippableHealth = equippableStats.healthBonus;
        PlayerStatsScript.UpdatePlayerStats();
        Debug.Log($"Attack is now {PlayerStatsScript.damage}");
        Debug.Log($"Health is now {PlayerStatsScript.maxHealth}");
        Debug.Log($"Speed is now {PlayerStatsScript.speed}");

        EquipWeaponOnJerbulcha();
    }

    private void EquipWeaponOnJerbulcha()
    {
        if (equippableName == "Claws of Thatsün")
        {
            leftClaw.SetActive(true);
            rightClaw.SetActive(true);

            leftTwinBlade.SetActive(false);
            rightTwinBlade.SetActive(false);
            leftGBB.SetActive(false);
            rightGBB.SetActive(false);
        }
        else if (equippableName == "Gauntlets of Boiling Blood")
        {
            leftGBB.SetActive(true);
            rightGBB.SetActive(true);

            leftTwinBlade.SetActive(false);
            rightTwinBlade.SetActive(false);
            leftClaw.SetActive(false);
            rightClaw.SetActive(false);
        }
        else if (equippableName == "Twin Blades")
        {
            leftTwinBlade.SetActive(true);
            rightTwinBlade.SetActive(true);

            leftClaw.SetActive(false);
            rightClaw.SetActive(false);
            leftGBB.SetActive(false);
            rightGBB.SetActive(false);
        }
    }

    public void UnequipStats()
    {
        PlayerStatsScript.speedBonus -= pastEquippableSpeed * 2;
        Debug.Log(PlayerStatsScript.speedBonus);
        PlayerStatsScript.damageBonus -= pastEquippableAttack * 2;
        Debug.Log(PlayerStatsScript.damageBonus);
        PlayerStatsScript.healthBonus -= pastEquippableHealth * 2;
        Debug.Log(PlayerStatsScript.healthBonus);
        equipButton.interactable = true;
        unequipButton.interactable = false;
        weaponEquipped = false;
        PlayerStatsScript.UpdatePlayerStats();
        PlayerStatsScript.speedBonus += pastEquippableSpeed;
        Debug.Log(PlayerStatsScript.speedBonus);
        PlayerStatsScript.damageBonus += pastEquippableAttack;
        Debug.Log(PlayerStatsScript.damageBonus);
        PlayerStatsScript.healthBonus += pastEquippableHealth;
        Debug.Log(PlayerStatsScript.healthBonus);
        Debug.Log($"Attack is now {PlayerStatsScript.damage}");
        Debug.Log($"Health is now {PlayerStatsScript.maxHealth}");
        Debug.Log($"Speed is now {PlayerStatsScript.speed}");
        UnequipWeapons();
    }

    private void UnequipWeapons()
    {
        leftTwinBlade.SetActive(false);
        rightTwinBlade.SetActive(false);
        leftClaw.SetActive(false);
        rightClaw.SetActive(false);
        leftGBB.SetActive(false);
        rightGBB.SetActive(false);
    }
}
