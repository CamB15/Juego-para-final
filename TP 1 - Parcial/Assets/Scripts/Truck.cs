using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
  
    private inventory inventory;
    private bool val;
    private bool inRange;
    public GameObject threadPrefab;


    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    void Update()
    {
        if (inventory.glass == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                SpawnThread();
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

    private void SpawnThread()
    {
        GameObject item = Instantiate(threadPrefab) as GameObject;
        item.transform.position = new Vector2(-17, -3);
    }
}

  


