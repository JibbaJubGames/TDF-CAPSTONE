using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuSubMenuSwitch : MonoBehaviour
{
    public GameObject menuToOpen;
    public GameObject [] menuToClose = new GameObject [3];
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
        menuToOpen.SetActive (true);
        menuToClose[0].SetActive (false);
        menuToClose[1].SetActive (false);
        menuToClose[2].SetActive (false);
    }
}
