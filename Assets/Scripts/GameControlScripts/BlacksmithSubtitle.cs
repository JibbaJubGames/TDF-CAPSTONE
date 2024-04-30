using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlacksmithSubtitle : MonoBehaviour
{
    public TMP_Text subtitleText;
    public AudioSource needSomethingLine;
    public GameObject BlacksmithUISet;
    public GameObject BlacksmithInteractorPrompt;
    public GameObject BlacksmithUpgradeMenu;

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
        NeedSomethingCheck();
        OpenCloseMenu();
    }

    private void OpenCloseMenu()
    {
        if (atCounter && Input.GetKeyDown(KeyCode.Return))
        { 
            BlacksmithUpgradeMenu.SetActive(true);
            BlacksmithInteractorPrompt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (atCounter && BlacksmithUpgradeMenu.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        { 
            BlacksmithUpgradeMenu.SetActive(false); 
            BlacksmithInteractorPrompt.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void NeedSomethingCheck()
    {
        if (needSomethingLine.isPlaying)
        {
            subtitleText.text = "BLACKSMITH: Hey there. Y'need something?";
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
        needSomethingLine.Play();
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
