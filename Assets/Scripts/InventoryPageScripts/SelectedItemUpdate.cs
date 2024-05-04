using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedItemUpdate : MonoBehaviour
{
    public static Image chosenItem;
    public static TMP_Text chosenText;
    public TMP_Text chosenDescriptionText;
    public static string itemType;
    // Start is called before the first frame update
    void Start()
    {
        chosenItem = GetComponentInChildren<Image>();
        chosenText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (itemType == "Health") chosenText.text = $"Health Crystal ({InventoryCount.healthCrystalCount})";
       // if (itemType == "Attack") chosenText.text = $"Attack Crystal ({InventoryCount.attackCrystalCount})";
       // if (itemType == "Steel") chosenText.text = $"Godly Steel ({InventoryCount.godlySteelCount})";
       // else chosenText.text = "";
    }
}
