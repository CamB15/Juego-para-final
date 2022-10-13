using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double_spawn : MonoBehaviour
{
    private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject prefab;
    public GameObject prefabTwo;
    private Dialogue dialogue;
    [SerializeField] private float moveX;
    [SerializeField] private float moveY;
    [SerializeField] private float posX;
    [SerializeField] private float posY;
    [SerializeField] private int i;
    [SerializeField] private int n;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {
        if (inventory.inInventory[i] == true)
        {
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                dialogue.inRange = false;
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                Spawn();
                Destroy(inventory.clone);
                inventory.inInventory[i] = false;
            }
        }
        else if (inventory.inInventory[n] == true)        
        {
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                val = myanim.GetBool("Change");
                val = false;
                myanim.SetBool("Change", val);
                SpawnTwo();
                Destroy(inventory.clone);
                inventory.inInventory[n] = false;
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

    private void Spawn()
    {
        GameObject item = Instantiate(prefab) as GameObject;
        item.transform.position = new Vector2(moveX, moveY);
    }
    private void SpawnTwo()
    {
        GameObject item = Instantiate(prefabTwo) as GameObject;
        item.transform.position = new Vector2(posX, posY);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);
    }
}

