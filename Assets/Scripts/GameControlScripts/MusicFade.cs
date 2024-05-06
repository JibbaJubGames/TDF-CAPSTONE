using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicFade : MonoBehaviour
{
    public int whichTrack = 1;
    public AudioSource background;
    public AudioSource battle;

    bool backgroundPlaying = false;
    bool battlePlaying = false;

    public static int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void IdleMusicFadeIn()
    {
        battle.volume = Mathf.Lerp(battle.volume, 0f, .2f * Time.deltaTime);
        if (battle.volume <= 0.1f)
        {
            battle.Stop();
        }
        background.volume = Mathf.Lerp(background.volume, .25f, .2f * Time.deltaTime);
        if (backgroundPlaying == false)
        {
            background.Play();
            backgroundPlaying = true;
            battlePlaying = false;
        }
    }
    public void BattleMusicFadeIn()
    {
        background.volume = Mathf.Lerp(background.volume, 0f, .4f * Time.deltaTime);
        if (background.volume <= 0.1f)
        {
            background.Stop();
        }
        battle.volume = Mathf.Lerp(battle.volume, .25f, .4f * Time.deltaTime);
        if (battlePlaying == false)
        {
            battle.Play();
            battlePlaying = true;
            backgroundPlaying = false;
        }
    }
}
