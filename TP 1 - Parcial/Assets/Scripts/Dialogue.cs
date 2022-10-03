using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(3, 6)] private string[] lines;

    public bool inRange;
    private bool dialogueStart;
    private int lineIndex;
    private float typingTime = 0.05f;
    public GameObject item;
    private GameObject clone;

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
        // activacion de UI y freeze de pantalla
        SpawnFace();
        dialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        lineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(Showline());
    }

    private IEnumerator Showline()
    {
        //para que se muestre cada caracter
        dialogueText.text = string.Empty;
        foreach (char ch in lines[lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }
    }
    private void NextLine()
    {
        //pase de linea - (modificar para que pase de linea dependiendo si tenes entregas item o no)
        lineIndex++;
        if (lineIndex < lines.Length)
        {
            StartCoroutine(Showline()); 
        }
        else
        {
            dialogueStart = false;
            dialoguePanel.SetActive(false);
            Destroy(clone);
            dialogueMark.SetActive(true);
            Time.timeScale = 1;
        }
    }

    private void SpawnFace()
    {
        clone = Instantiate(item, dialoguePanel.transform, false);  
    }

  
}
