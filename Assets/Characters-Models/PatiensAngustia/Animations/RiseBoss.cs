using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseBoss : MonoBehaviour
{
    [Header("Boss Info")]
    public GameObject boss;
    public Animator bossAnim;
    public AudioSource bossRumble;

    [Header("Player Info")]
    public GameObject player;
    public GameObject playerAudio;
    public GameObject playerPoint;
    public ThirdPersonMovement playerControl;

    [Header("Camera Info")]
    public CinemachineFreeLook playerCam;
    public CinemachineVirtualCamera panAroundCam;
    public Animator panAroundCamAnim;

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
            MusicFade.enemyCount++;
            bossAnim.SetTrigger("It's Time...");
            boss.transform.position = Vector3.Lerp(boss.transform.position, new Vector3(boss.transform.position.x, 25.5f, boss.transform.position.z), .05f);
            player.transform.position = playerPoint.transform.position;
            playerAudio.SetActive(false);
            playerControl.enabled = false;
            player.GetComponentInChildren<Animator>().enabled = false;
            playerCam.gameObject.SetActive(false);
            panAroundCam.gameObject.SetActive(true);
            panAroundCamAnim.SetTrigger("It's Time...");
        }
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