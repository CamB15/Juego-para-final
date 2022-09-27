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



    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
    }

    void Update()
    {
        if (inventory.rock == true)
        {
            if (inRange && Input.GetButtonDown("Fire1"))
            {
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
        item.transform.position = new Vector2(10, -0);
    }
}

  
