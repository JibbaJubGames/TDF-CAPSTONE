using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelector : MonoBehaviour
{
    //ATTACH THIS SCRIPT TO CHARACTER/ENTITY EMITTING AUDIO
    //CHARACTER/ENTITY SHOULD HAVE AN AUDIO HOLDER COMPONENT HOLDING ALL AUDIO SOURCES THAT
    //WILL BE USED FOR THIS CHARACTER/ENTITY

    [Header("Effort Sound Effects")]
    public AudioSource[] effortSounds;

    [Header("Movement Sound Effects")]
    public AudioSource walkingSound;
    public AudioSource runningSound;

    //Use for sounds that are necessary to the character/entity but don't quite fit the other spaces
    [Header("Specialty Sound Effects")]
    public AudioSource specialtySoundOne;
    public AudioSource specialtySoundTwo;
    public AudioSource specialtySoundThree;

    [Header("Voice Lines")]
    public AudioSource[] voiceLines;

    [Header("Animator to prompt sound from")]
    public Animator soundPromptSource;

    [Header("Animator Prompt Titles")]
    public string walkingPrompt;
    public string runningPrompt;
    public string effortPrompt;
    public string jumpCheck;
    public string effortCheck;

    [Header("Sound Effect Locks")]
    public bool walkingSoundOn = false;
    public bool runningSoundOn = false;
    public bool effortSoundOn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkAndRunSoundCheck();
    }

    public void EffortSoundCheck()
    {
        int randomEffort = Random.Range(0, 5);
        effortSounds[randomEffort].Play();
        Debug.Log($"Playing effort sound {randomEffort}");
    }

    private void WalkAndRunSoundCheck()
    {
        //Checks if walking but not running
        if (soundPromptSource.GetBool(walkingPrompt) == true && !walkingSoundOn && !runningSoundOn )
        {
            walkingSound.Play();
            walkingSoundOn = true;
        }
        //Checks if running but not walking
        else if (soundPromptSource.GetBool(runningPrompt) == true && !runningSoundOn)
        {
            Debug.Log("We running");
            walkingSound.Stop();
            runningSound.Play();
            runningSoundOn = true;
            walkingSoundOn = false;
        }
        //Checks running AND walking to see if standing still
        else if (soundPromptSource.GetBool(runningPrompt) == false || PlayerHealth.midAttack)
        {
            runningSound.Stop();
            runningSoundOn = false;
            if (soundPromptSource.GetBool(walkingPrompt) == false || PlayerHealth.midAttack)
            {
                walkingSound.Stop();
                walkingSoundOn = false;
            }
        }
    }

    public void SpecialtySounds(int specialtyNumber)
    {
        if (specialtyNumber == 1)
        {
            specialtySoundOne.Play();
        }
        else if (specialtyNumber == 2)
        {
            specialtySoundTwo.Play();
        }
        else if (specialtyNumber == 3)
        {
            specialtySoundThree.Play();
        }
    }
}
