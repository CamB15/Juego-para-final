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
        if (inventory.rock == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                SpawnGlass();
                // falta hacer que se quite del inventario y que el slot se pueda volver a usar

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

  