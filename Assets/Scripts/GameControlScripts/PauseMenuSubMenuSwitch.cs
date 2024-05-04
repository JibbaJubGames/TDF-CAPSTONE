using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSubMenuSwitch : MonoBehaviour
{
    public GameObject menuToOpen;
    public GameObject menuToClose;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchMenu()
    {
        menuToOpen.SetActive(true);
        menuToClose.SetActive(false);
        
    }
}
