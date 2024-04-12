using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelector : MonoBehaviour
{
    [Header("Effort Sound Effects")]
    public AudioSource[] effortSounds;

    [Header("Movement Sound Effects")]
    public AudioSource walkingSound;
    public AudioSource runningSound;

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

    private void WalkAndRunSoundCheck()
    {
        //Checks if walking but not running
        if (soundPromptSource.GetBool(walkingPrompt) == true && !walkingSoundOn && !runningSoundOn)
        {
            Debug.Log("We're walking here");
            walkingSound.Play();
            walkingSoundOn = true;
        }
        //Checks if running but not walking
        else if (soundPromptSource.GetBool(runningPrompt) == true && !runningSoundOn)
        {
            walkingSound.Stop();
            runningSound.Play();
            runningSoundOn = true;
            walkingSoundOn = false;
        }
        //Checks running AND walking to see if standing still
        else if (soundPromptSource.GetBool(walkingPrompt) == false)
        {
            walkingSound.Stop();
            walkingSoundOn = false;
        }
        else if (soundPromptSource.GetBool(runningPrompt) == false)
        {
            runningSound.Stop();
            runningSoundOn = false;
        }
    }
}
