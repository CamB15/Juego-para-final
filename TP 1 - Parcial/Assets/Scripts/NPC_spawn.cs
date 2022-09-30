using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_spawn : MonoBehaviour
{
     private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject codePrefab;
    private Dialogue dialogue;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (inventory.tiger == true)
        {
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            {
               // val = myanim.GetBool("Change");
               // val = true;
               // myanim.SetBool("Change", val);
                SpawnNum();
                Destroy(inventory.clone);
                inventory.tiger = false;
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

    private void SpawnNum()
    {
        GameObject item = Instantiate(codePrefab) as GameObject;
        item.transform.position = new Vector2(1.96f, 0.7f);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);
    }

}
