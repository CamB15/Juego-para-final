using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree_spawn : MonoBehaviour
{
    private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject tigerPrefab;
    private Dialogue dialogue;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        // chequeo de inventario
    if (inventory.inInventory[6] == true)
    {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
             val = myanim.GetBool("Change");
             val = true;
             myanim.SetBool("Change", val);
             Destroy(inventory.clone);
             inventory.inInventory[6] = false;
            }    
    }
    else if (inventory.inInventory[4] == true)
    {
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            { 
             val = myanim.GetBool("Change");
             val = false;
             myanim.SetBool("Change", val);
             SpawnTiger();
             Destroy(inventory.clone);
             inventory.inInventory[4] = false;
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

    private void SpawnTiger()
    {
        //spawn item
        GameObject item = Instantiate(tigerPrefab) as GameObject;
        item.transform.position = new Vector2(4.4f, -8f);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);

    }
}
