using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private inventory inventory;
    private Animator myanim;
    private bool val;
    private bool inRange;
    public GameObject prefab;
    private Dialogue dialogue;
    public int i;
    public float moveX;
    public float moveY;

    void Start()
    { //traer componentes
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
        myanim = GetComponent<Animator>();
        dialogue = GetComponent<Dialogue>();
    }

    void Update()
    {//chequeo de inventario
        if (inventory.inInventory[i] == true)
        { //cambio de animacion
            dialogue.inRange = false;
            if (inRange && Input.GetButtonDown("Fire1"))
            {
                val = myanim.GetBool("Change");
                val = true;
                myanim.SetBool("Change", val);
                Spawn();
                Destroy(inventory.clone);
                inventory.inInventory[i] = false;
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
    { //spawn de item y destruccion de dialogo
        GameObject item = Instantiate(prefab) as GameObject;
        item.transform.position = new Vector2(moveX, moveY);
        Destroy(dialogue);
        Destroy(dialogue.dialogueMark);
    }

}
