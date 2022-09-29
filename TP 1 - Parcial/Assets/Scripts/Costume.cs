using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Costume : MonoBehaviour
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
        if (inventory.thread == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                SpawnCode();
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

    private void SpawnCode()
    {
        GameObject item = Instantiate(codePrefab) as GameObject;
        item.transform.position = new Vector2(10, -1);
    }
}
