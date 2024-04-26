using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBoxScript : MonoBehaviour
{
    public GameObject BreakableBox;
    private ItemDrop dropItem;
    bool itemSpawned = false;
    bool boxSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        dropItem = GetComponent<ItemDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jerbulcha is hitting the box");
            if (!boxSpawned)BreakableBox = Instantiate(BreakableBox,transform.position, transform.rotation); boxSpawned = true;
            if (!itemSpawned) dropItem.DropRandomItem(); itemSpawned = true;
            Object.Destroy(this.gameObject,.2f);
        }
    }
}
