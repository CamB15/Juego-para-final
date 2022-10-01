using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject glassPrefab;
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
            if (inventory.inInventory[0] == true)
            {
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                SpawnGlass();
                Destroy(inventory.clone);
            }
            else if (inventory.inInventory[8] == true)
            { //hacer que aparescan enemigos
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = false;
                myanim.SetBool("Change", val);
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

    private void SpawnGlass()
    {
        GameObject item = Instantiate(glassPrefab) as GameObject;
        item.transform.position = new Vector2(10, -1);
    }
}

  
