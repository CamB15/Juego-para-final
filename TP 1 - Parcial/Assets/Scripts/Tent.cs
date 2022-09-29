using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{

    private inventory inventory;
    private bool inRange;
    public GameObject boxPrefab;
    private Dialogue dialogue;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (inventory.rock == true)
            {
                dialogue.inRange = false;
                SpawnGlass();
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
        GameObject item = Instantiate(boxPrefab) as GameObject;
        item.transform.position = new Vector2(10, -1);
    }
}
