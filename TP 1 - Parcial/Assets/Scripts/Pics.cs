using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pics : MonoBehaviour
{
    private inventory inventory;
    private bool inRange;
    private Dialogue dialogue;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        dialogue = GetComponent<Dialogue>();
    }
    void Update()
    {
        if (inventory.inInventory[1] == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                Destroy(dialogue);
                Destroy(dialogue.dialogueMark);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = false;

        }
    }
}
