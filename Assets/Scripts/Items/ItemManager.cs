using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("Item Count and Reset")]
    public static int attackCrystalCount = 0;
    public static int healthCrystalCount = 0;
    public static int godlySteelCount = 0;
    public static float itemCountReset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemCountReset += Time.deltaTime;
        if (itemCountReset > 2.5f)
        {
            ItemCountReset();
            itemCountReset = 0;
        }
    }

    private void ItemCountReset()
    {
        attackCrystalCount = 0;
        healthCrystalCount = 0;
        godlySteelCount = 0;
    }
}
