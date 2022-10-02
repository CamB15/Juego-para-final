using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_code : MonoBehaviour
{
    public GameObject codeNum;
    private GameObject item;
    private bool inRange;
    private bool flipflop = false;
    [SerializeField] private int i;
    private Dialogue dialogue;
    private inventory inventory;

    void Start ()
    {
        dialogue = GetComponent<Dialogue>();
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }
    void Update()
    {
        if(this.CompareTag("Tent"))
        { 
            if (inventory.inInventory[i] == true)
            {
                dialogue.inRange = false;
                if (inRange && Input.GetButtonDown("Fire1"))
                {
                    if (flipflop == false)
                    {
                        SpawnCode();
                        flipflop = !flipflop;
                        Time.timeScale = 0;
                    }
                    else
                    {
                        flipflop = !flipflop;
                        Destroy(item);
                        Time.timeScale = 1;
                    }
                    Destroy(dialogue);
                    Destroy(dialogue.dialogueMark);
                }
            }
        }
        else
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                if (flipflop == false)
                {
                    SpawnCode();
                    flipflop = !flipflop;
                    Time.timeScale = 0;
                }
                else
                {
                    flipflop = !flipflop;
                    Destroy(item);
                    Time.timeScale = 1;
                }
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
    private void SpawnCode()
    {
        item = Instantiate(codeNum, GameObject.FindGameObjectWithTag("Canvas").transform, false);
    }
}
