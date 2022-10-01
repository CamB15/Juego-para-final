using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_code : MonoBehaviour
{
    public GameObject codeNum;
    private GameObject item;
    private bool inRange;
    private bool flipflop = false;

    void Update()
    {
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (flipflop == false)
            {
                SpawnCode();
                flipflop = !flipflop;
                Time.timeScale = 0;
            }
            else
            {
                flipflop = !flipflop;
                Destroy(item);
                Time.timeScale = 1;
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
        item = Instantiate(codeNum, GameObject.FindGameObjectWithTag("Player").transform, false);
    }
}
