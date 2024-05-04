using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlacksmithSubtitle : MonoBehaviour
{
    [Header("Voice Lines")]
    public AudioSource GreetingLine;
    public AudioSource OpenMenuLine;
    public AudioSource InsufficientMaterialsLine;
    public AudioSource UpgradePurchaseLine;
    public AudioSource CloseMenuLine;
    
    

    [Header("Blacksmith Menu UI")]
    public GameObject BlacksmithUISet;
    public GameObject BlacksmithInteractorPrompt;
    public GameObject BlacksmithUpgradeMenu;
    
    public TMP_Text subtitleText;
    private bool atCounter = false;
    private Animator blacksmithAnim;
    // Start is called before the first frame update
    void Start()
    {
        blacksmithAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SubtitleSetter();
        OpenCloseMenu();
    }

    private void LineEscapeClause(int thisLine)
    {
        if (thisLine != 1) GreetingLine.Stop();
        if (thisLine != 2) OpenMenuLine.Stop();
        if (thisLine != 3) InsufficientMaterialsLine.Stop();
        if (thisLine != 4) UpgradePurchaseLine.Stop();
        if (thisLine != 5) CloseMenuLine.Stop();
    }

    private void OpenCloseMenu()
    {
        if (atCounter && Input.GetKeyDown(KeyCode.Return))
        {
            Time.timeScale = 0;
            BlacksmithUpgradeMenu.SetActive(true);
            BlacksmithInteractorPrompt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (atCounter && BlacksmithUpgradeMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1;
            BlacksmithUpgradeMenu.SetActive(false); 
            CloseMenuLine.Play();
            LineEscapeClause(5);
            BlacksmithInteractorPrompt.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void SubtitleSetter()
    {
        if (GreetingLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: Hey there. Y'need something?";
        }
        else if (OpenMenuLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: I'll do what I can with what y'got.";
        }
        else if (InsufficientMaterialsLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: Y'ain't got the scrap, girlie...";
        }
        else if (UpgradePurchaseLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: Gimme a minute... I'll see what I can whip up.";
        }
        else if (CloseMenuLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: Suit yourself...";
        }
        else
        {
            subtitleText.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        BlacksmithUISet.SetActive(true);
        blacksmithAnim.SetTrigger("PlayerClose");
        GreetingLine.Play();
        LineEscapeClause(1);
        BlacksmithInteractorPrompt.SetActive(true);
        atCounter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        BlacksmithUISet.SetActive(false);
        BlacksmithInteractorPrompt.SetActive(false);
        BlacksmithUpgradeMenu.SetActive(false);
        atCounter = false;
    }
}
