using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectedWeaponUpdate : MonoBehaviour
{
    public static Image chosenItem;
    public static TMP_Text chosenText;
    public TMP_Text chosenDescriptionText;
    // Start is called before the first frame update
    void Start()
    {

        chosenItem = GetComponentInChildren<Image>();
        chosenText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
