using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class RiseBoss : MonoBehaviour
{
    [Header("Boss Info")]
    public GameObject boss;
    public Animator bossAnim;
    public AudioSource bossRumble;
    public AudioSource bossBreathe;

    [Header("Player Info")]
    public GameObject player;
    public GameObject playerAudio;
    public GameObject playerPoint;
    public ThirdPersonMovement playerControl;

    [Header("Camera Info")]
    public CinemachineFreeLook playerCam;
    public CinemachineVirtualCamera panAroundCam;
    public Animator panAroundCamAnim;

    [Header("Boss Health")]
    public Slider bossBar;
    public Image bossBarHolder;
    public TMP_Text bossTitle;
    public GameObject bossHealthUI;
    public float appearSpeed;
    public static float bossInfoLoad;

    [Header("The End")]
    public Image goodbyeBackground;
    public TMP_Text[] goodbyeText;
    public Image gameLogo;
    public GameObject[] otherUI;
    private int uiCount;

    private bool itsTime = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itsTime == true)
        {
            BossEnterBattle();
            FreezePlayer();
            FightCamPan();
            BossInfoFadeIn();
            GoodbyePage();
        }
    }

    private void GoodbyePage()
    {
        if (bossInfoLoad > 10 && bossInfoLoad < 20f)
        {
            if (uiCount < otherUI.Length)
            {
                otherUI[uiCount].gameObject.SetActive(false);
                Debug.Log(otherUI[uiCount].gameObject.name + "should be off now");
                uiCount++;
            }
            goodbyeBackground.color = Color.Lerp(goodbyeBackground.color, Color.black, appearSpeed * Time.deltaTime);
            goodbyeText[0].color = Color.Lerp(goodbyeText[0].color, Color.white, appearSpeed * Time.deltaTime);
            goodbyeText[1].color = Color.Lerp(goodbyeText[1].color, Color.white, appearSpeed * Time.deltaTime);
            goodbyeText[2].color = Color.Lerp(goodbyeText[2].color, Color.white, appearSpeed * Time.deltaTime);
        }
        if (bossInfoLoad > 20f)
        {
            goodbyeBackground.color = Color.Lerp(goodbyeBackground.color, Color.black, appearSpeed * Time.deltaTime);
            goodbyeText[0].color = Color.Lerp(goodbyeText[0].color, Color.clear, appearSpeed * Time.deltaTime);
            goodbyeText[1].color = Color.Lerp(goodbyeText[1].color, Color.clear, appearSpeed * Time.deltaTime);
            goodbyeText[2].color = Color.Lerp(goodbyeText[2].color, Color.clear, appearSpeed * Time.deltaTime);
            gameLogo.color = Color.Lerp(gameLogo.color, Color.white, appearSpeed * Time.deltaTime * 2);
        }
    }

    public void BossBreathSound()
    {
        bossBreathe.Play();
    }


    private void BossInfoFadeIn()
    {
        bossInfoLoad += Time.deltaTime;
        if (bossInfoLoad > 0.75f && bossInfoLoad < 10f)
        {
            bossHealthUI.SetActive(true);
            bossTitle.color = Color.Lerp(bossTitle.color, Color.white, appearSpeed * Time.deltaTime);
            bossBarHolder.color = Color.Lerp(bossBarHolder.color, Color.white, appearSpeed * Time.deltaTime);
            bossBar.value += appearSpeed * Time.deltaTime / 2;
        }
    }

    private void FightCamPan()
    {
        playerCam.gameObject.SetActive(false);
        panAroundCam.gameObject.SetActive(true);
        panAroundCamAnim.SetTrigger("It's Time...");
    }

    private void FreezePlayer()
    {
        player.transform.position = playerPoint.transform.position;
        playerAudio.SetActive(false);
        playerControl.enabled = false;
        player.GetComponentInChildren<Animator>().enabled = false;
    }

    private void BossEnterBattle()
    {
        MusicFade.enemyCount++;
        bossAnim.SetTrigger("It's Time...");
        boss.transform.position = Vector3.Lerp(boss.transform.position, new Vector3(boss.transform.position.x, 25.5f, boss.transform.position.z), .05f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            itsTime = true;
        }
    }

    public void RumbleSound()
    {
        bossRumble.Play();
    }
}