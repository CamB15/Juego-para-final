using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject talk;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(3, 6)] private string[] lines;

    private bool inRange;
    private bool dialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;

    void Update()
    {
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (!dialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == lines[lineIndex])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[lineIndex];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = true;
            dialogueMark.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = false;
            dialogueMark.SetActive(false);
        }
    }

    private void StartDialogue()
    {
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        talk.SetActive(true);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(Showline());
    }

    private IEnumerator Showline()
    {
        dialogueText.text = string.Empty;
        foreach (char ch in lines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }

    void NextLine()
    {
        lineIndex++;
        if (lineIndex < lines.Length)
        {
            StartCoroutine(Showline());
        }
        else
        {
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            talk.SetActive(false);
            Time.timeScale = 1;
        }

    }
}
