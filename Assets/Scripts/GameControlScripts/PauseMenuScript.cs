using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    public static bool paused;
    public GameObject pauseMenu;
    public float pauseTimer;

    public GameObject InventoryPage;
    public GameObject WeaponsPage;
    public GameObject BoonsPage;
    public GameObject OptionsPage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseTimer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.Escape) && !paused && pauseTimer > 0.5f && PlayerHealth.playerHealth >= 1 && RiseBoss.bossInfoLoad < 10f) 
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            paused = true;
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            pauseTimer = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && paused && pauseTimer == 0f) 
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            paused = false;
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            ResetPauseMenu();
        }
    }

    public void ResetPauseMenu()
    {
        InventoryPage.SetActive(false);
        WeaponsPage.SetActive(false);
        BoonsPage.SetActive(false);
        OptionsPage.SetActive(false);
    }
}
