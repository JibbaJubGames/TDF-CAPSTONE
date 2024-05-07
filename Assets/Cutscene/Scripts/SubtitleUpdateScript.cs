using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SubtitleUpdateScript : MonoBehaviour
{
    public TMP_Text openingSubtitles;
    public string[] subtitleTexts;
    public int currentSubtitle;
    public bool musicStarted = false;
    public AudioSource music;
    // Start is called before the first frame update
    void Start()
    {
        currentSubtitle = 0;
        openingSubtitles.text = subtitleTexts[currentSubtitle];
    }

    // Update is called once per frame
    void Update()
    {
        if (musicStarted) music.volume = Mathf.Lerp(music.volume, 0.15f, .1f * Time.deltaTime);
    }

    public void NextLine()
    {
        currentSubtitle++;
        openingSubtitles.text = subtitleTexts[currentSubtitle];
    }

    public void MusicStart()
    {
        music.Play();
        musicStarted = true;
        
    }

    public void MusicStop()
    {
        music.Stop();
    }

    public void CutsceneOver(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
