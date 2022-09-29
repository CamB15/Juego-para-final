using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_swing : MonoBehaviour
{
    private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject woodPrefab;
    private Dialogue dialogue;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (inventory.lights == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                dialogue.NextLine();
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                SpawnWood();
                Destroy(inventory.clone);
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

    private void SpawnWood()
    {
        GameObject item = Instantiate(woodPrefab) as GameObject;
        item.transform.position = new Vector2(-3.5f, 2.5f);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);
    }

  
}
