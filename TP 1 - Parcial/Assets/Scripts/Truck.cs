using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
  
    private inventory inventory;
    private bool val;
    private bool inRange;
    public GameObject threadPrefab;
    private Dialogue dialogue;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (inventory.glass == true)
        {
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                SpawnThread();
                Destroy(inventory.clone);
                inventory.glass = false;
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

    private void SpawnThread()
    {
        GameObject item = Instantiate(threadPrefab) as GameObject;
        item.transform.position = new Vector2(-17, -3);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);
    }
}

  


