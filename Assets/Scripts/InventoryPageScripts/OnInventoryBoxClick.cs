using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnInventoryBoxClick : MonoBehaviour
{
    public Image thisItem;
    public string thisItemName;
    public string thisItemDescription;

    public string thisItemType;
    public int itemCount;

    public SelectedItemUpdate selection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (thisItemType == "Health") itemCount = InventoryCount.healthCrystalCount;   
        if (thisItemType == "Attack") itemCount = InventoryCount.attackCrystalCount;   
        if (thisItemType == "Steel") itemCount = InventoryCount.godlySteelCount;   
    }

    public void UpdateSelection()
    {
        SelectedItemUpdate.chosenItem.sprite = thisItem.sprite;
        if (thisItemType == "") SelectedItemUpdate.chosenText.text = "";
        else if (thisItemType == "Weapon") SelectedItemUpdate.chosenText.text = thisItemName;
        else SelectedItemUpdate.chosenText.text = thisItemName + $" ({itemCount})";
        selection.chosenDescriptionText.text = thisItemDescription;
        SelectedItemUpdate.itemType = thisItemType;
    }
}
