using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private Object[] itemPool = new Object[3];
    [SerializeField]
    private GameObject spawn;

    private void Start()
    {
        //itemPool = new Object[itemPool.Length];
    }

    private void DropRandomItem()
    {
        //to drop a random item from the array
        Instantiate(itemPool[Random.Range(0, itemPool.Length)],spawn.transform);
        Debug.Log("dropped random item");
    }

    private void DropSpecificItem()
    {   //wil only drop the item in the 0 position of the array
        Instantiate(itemPool[0],spawn.transform);
        Debug.Log("dropped specific item");
    }

    private void Update()
    {
        //to do: make an actual trigger to drop an item
        if (Input.GetKeyDown(KeyCode.E))
        {
            DropSpecificItem();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            DropRandomItem();
        }
    }

}
