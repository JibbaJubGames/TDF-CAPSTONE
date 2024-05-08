using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;
using Unity.VisualScripting;

public class BossRumble : MonoBehaviour
{
    public NoiseSettings BossRumbleShake;
    public CinemachineFreeLook thirdPersonCam;
    public float rumbleTimer;
    public bool hasRumbled = false;
    public AudioSource rumble;
    // Start is called before the first frame update
    void Start()
    {
        rumbleTimer = 4.6f;
    }

    // Update is called once per frame
    void Update()
    {
        rumbleTimer += Time.deltaTime;
        if (rumbleTimer < 4.5f)
        {
            thirdPersonCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = BossRumbleShake;
            thirdPersonCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = BossRumbleShake;
            thirdPersonCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = BossRumbleShake;
        }
        else 
        {
        thirdPersonCam.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = null;
        thirdPersonCam.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = null;
        thirdPersonCam.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_NoiseProfile = null;
        } 

        if (rumbleTimer > 4.6f && hasRumbled)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == true && !hasRumbled)
        {
            hasRumbled = true;
            rumbleTimer = 0;
            rumble.Play();
        }
    }
}
