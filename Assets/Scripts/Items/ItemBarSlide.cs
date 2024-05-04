using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemBarSlide : MonoBehaviour
{
    [Header("Item Bars")]
    public GameObject healthItemBar;
    public GameObject attackItemBar;
    public GameObject steelItemBar;

    [Header("Item Bar Checks")]
    public bool healthItemBarOut = false;
    public bool attackItemBarOut = false;
    public bool steelItemBarOut = false;

    [Header("Item Bar Positions")]
    private Vector3 healthOffScreen;
    private Vector3 healthOnScreen;

    private Vector3 attackOffScreen;
    private Vector3 attackOnScreen;
    
    private Vector3 steelOffScreen;
    private Vector3 steelOnScreen;
    
    
    
    public bool itemPicked;
    public int itemTypes;
    // Start is called before the first frame update
    void Start()
    {
        healthOffScreen = new Vector3(-750, healthItemBar.transform.position.y, 0);
        healthOnScreen = new Vector3(250, healthItemBar.transform.position.y, 0);

        attackOffScreen = new Vector3(-750, attackItemBar.transform.position.y, 0);
        attackOnScreen = new Vector3(250, attackItemBar.transform.position.y, 0);
        
        steelOffScreen = new Vector3(-750, steelItemBar.transform.position.y, 0);
        steelOnScreen = new Vector3(250, steelItemBar.transform.position.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        HealthItemBarAppear();
        HealthItemBarDisappear();

        AttackItemBarAppear();
        AttackItemBarDisappear();

        SteelItemBarAppear();
        SteelItemBarDisappear();
    }


    //MOVE ALL ITEM BARS IN AND OUT (Rudimentary for Minimum Viable Product, repeating code)
    private void HealthItemBarAppear()
    {
        if (ItemManager.healthCrystalCount != 0) { healthItemBar.transform.position = Vector3.MoveTowards(healthItemBar.transform.position, healthOnScreen, 2500 * Time.deltaTime); Debug.Log("HealthBarShouldBeHere"); }
        if (Vector3.Distance(healthItemBar.transform.position, healthOnScreen) <= 0.5f) healthItemBarOut = true;
    }
    private void HealthItemBarDisappear()
    {
        if (ItemManager.healthCrystalCount == 0) { healthItemBar.transform.position = Vector3.MoveTowards(healthItemBar.transform.position, healthOffScreen, 2500 * Time.deltaTime); }
        if (Vector3.Distance(healthItemBar.transform.position, healthOffScreen) <= 0.5f) healthItemBarOut = false;
    }
    
    private void AttackItemBarAppear()
    {
        if (ItemManager.attackCrystalCount != 0) {attackItemBar.transform.position = Vector3.MoveTowards(attackItemBar.transform.position, attackOnScreen, 2500 * Time.deltaTime); }
        if (Vector3.Distance(attackItemBar.transform.position, healthOnScreen) <= 0.5f) attackItemBarOut = true;
    }
    private void AttackItemBarDisappear()
    {
        if (ItemManager.attackCrystalCount == 0) { attackItemBar.transform.position = Vector3.MoveTowards(attackItemBar.transform.position, attackOffScreen, 2500 * Time.deltaTime); }
        if (Vector3.Distance(attackItemBar.transform.position, healthOffScreen) <= 0.5f) attackItemBarOut = false;
    }
    private void SteelItemBarAppear()
    {
        if (ItemManager.godlySteelCount != 0) { steelItemBar.transform.position = Vector3.MoveTowards(steelItemBar.transform.position, steelOnScreen, 2500 * Time.deltaTime); }
        if (Vector3.Distance(steelItemBar.transform.position, healthOnScreen) <= 0.5f) steelItemBarOut = true;
    }
    private void SteelItemBarDisappear()
    {
        if (ItemManager.godlySteelCount == 0) { steelItemBar.transform.position = Vector3.MoveTowards(steelItemBar.transform.position, steelOffScreen, 2500 * Time.deltaTime); }
        if (Vector3.Distance(steelItemBar.transform.position, healthOffScreen) <= 0.5f) steelItemBarOut = false;
    }
}
