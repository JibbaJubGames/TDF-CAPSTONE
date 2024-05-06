using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OnWeaponBoxClick : MonoBehaviour
{
    public Image thisItem;
    public string thisItemName;
    public string thisItemDescription;


    public WeaponStatsHolder thisItemStats;
    public EquipButton clickToEquip;
    public SelectedWeaponUpdate selection;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateSelection()
    {
        SelectedWeaponUpdate.chosenItem.sprite = thisItem.sprite;
        SelectedWeaponUpdate.chosenText.text = thisItemName;
        selection.chosenDescriptionText.text = thisItemDescription;
        
        clickToEquip.equippableStats = thisItemStats;
        clickToEquip.equippableName = thisItemName;
        
        thisItemStats.UpdateStatsText();
    }
}
