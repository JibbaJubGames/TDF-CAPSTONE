using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipCutscene : MonoBehaviour
{
    public float startCountdown;
    public bool readyToSkip;
    public TMP_Text skipCutscene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    if (readyToSkip)
        {
            startCountdown += Time.deltaTime;
            skipCutscene.color = Color.Lerp (skipCutscene.color, Color.white, 2 * Time.deltaTime);
        }
        if (startCountdown > 5)
        {
            readyToSkip = false;
            startCountdown = 0;
        }
        else if (startCountdown == 0)
        {
            skipCutscene.color = Color.Lerp(skipCutscene.color, Color.clear, 2 * Time.deltaTime);
        }
    }

    public void CutsceneSkipClick()
    {
        readyToSkip = true;

        if (readyToSkip && startCountdown > .5f) 
        {
            CutsceneOver("LevelScene");
        }
    }

    public void CutsceneOver(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }
}
