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
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (inventory.inInventory[6] == true)
            {
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                Destroy(inventory.clone);
            }
            else if (inventory.inInventory[4] == true)
            {
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = false;
                myanim.SetBool("Change", val);
                SpawnTiger();
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

    private void SpawnTiger()
    {
        GameObject item = Instantiate(tigerPrefab) as GameObject;
        item.transform.position = new Vector2(-6.3f, -8.4f);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);

    }
}
