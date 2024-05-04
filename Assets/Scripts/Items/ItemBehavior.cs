using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{   
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    private float jumpForce = 200f;
    [SerializeField]
    private float rotationSpeed = 65f;
    [SerializeField]
    private GameObject GameObject;

    private Vector3 m_EulerAngleVelocity;

    public string itemName;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.parent = null;
        this.transform.localScale = Vector3.one;
        rb.AddForce(transform.up * jumpForce);
        
        m_EulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (itemName == "Health") pickUpInfoFill(1);
            if (itemName == "Attack") pickUpInfoFill(2);
            if (itemName == "Steel") pickUpInfoFill(3);
            //TO DO: implement something actually happening when you pick up an item and also maybe a sound effect
            Destroy(gameObject);
        }
    }

    private void pickUpInfoFill(int itemType)
    {
        if (itemType == 1)
        {
            ItemManager.healthCrystalCount++;
            InventoryCount .healthCrystalCount++;
        }
        if (itemType == 2)
        {
            ItemManager.attackCrystalCount++;
            InventoryCount.attackCrystalCount++;
        }

        if (itemType == 3)
        {
            ItemManager.godlySteelCount++;
            InventoryCount.godlySteelCount++;
        }
        ItemManager.itemCountReset = 0f;
    }

}
