using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public GameObject deathMenu;
    public GameObject[] otherUI;
    private int uiCount;

    public TMP_Text quit;
    public TMP_Text restart;
    public TMP_Text jerbulchaDead;
    public Image background;
    public AudioListener audioListener;

    public float deathCounter;

    private bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            deathCounter += Time.deltaTime;
            if (deathCounter >= 3) 
            {
            DeathScreenFadeIn();
            AudioListener.volume = Mathf.Lerp(AudioListener.volume, 0, .5f * Time.deltaTime);         
            }
        }
    }

    private void DeathScreenFadeIn()
    {
        background.color = Color.Lerp(background.color, Color.black, .5f * Time.deltaTime);
        quit.color = Color.Lerp(quit.color, Color.white, .5f * Time.deltaTime);
        restart.color = Color.Lerp(restart.color, Color.white, .5f * Time.deltaTime);
        jerbulchaDead.color = Color.Lerp(jerbulchaDead.color, new Color(180,0,0,255), .5f * Time.deltaTime);
        if (uiCount < otherUI.Length)
        {
            otherUI[uiCount].gameObject.SetActive(false);
            uiCount++;
        }
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void PlayerHasDied()
    {
        deathMenu.gameObject.SetActive(true);
        isDead = true;
    }
}
