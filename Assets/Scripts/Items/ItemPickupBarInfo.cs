using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickupBar : MonoBehaviour
{
    [Header("Item Info")]
    public TMP_Text itemPickup;
    public string itemType;
    // Start is called before the first frame update
    void Start()
    {
        itemPickup = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (itemType == "Health") { HealthCrystalInfo(); }
        if (itemType == "Attack") { AttackCrystalInfo(); }
        if (itemType == "Steel") { GodlySteelInfo(); }
    }
    public void AttackCrystalInfo()
    {
        itemPickup.text = $"Obtained: Attack Crystal ({ItemManager.attackCrystalCount})";
    }

    public void HealthCrystalInfo()
    {
        itemPickup.text = $"Obtained: Health Crystal ({ItemManager.healthCrystalCount})";
    }

    public void GodlySteelInfo()
    {
        itemPickup.text = $"Obtained: Godly Steel ({ItemManager.godlySteelCount})";
    }


    
}
