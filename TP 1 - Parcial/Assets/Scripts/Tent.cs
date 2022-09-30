using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tent : MonoBehaviour
{

    private inventory inventory;
    private bool inRange;
    public GameObject boxPrefab;
    private bool isBox = false;
    public GameObject dialogueMark;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }

    void Update()
    {
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (isBox == false)
            {
                SpawnBox();
            }  
        }
    }

    void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = true;
            dialogueMark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = false;
            dialogueMark.SetActive(false);
        }
    }

    private void SpawnBox()
    {
        GameObject item = Instantiate(boxPrefab) as GameObject;
        item.transform.position = new Vector2(-5.9f, -7f);
        isBox = true;
        Destroy(dialogueMark);
    }
}
