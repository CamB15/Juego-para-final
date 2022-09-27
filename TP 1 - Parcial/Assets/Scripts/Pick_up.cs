using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_up : MonoBehaviour
{
    private inventory inventory;
    public GameObject item;
    private bool inRange;
   
 
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }
    void OnTriggerEnter2D (Collider2D other)
    {   //chequea si el que entra a la colision es el jugador
        if(other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void Update()
    {
        if (inRange && Input.GetButtonDown("Fire1"))
        {
            if (this.tag == "Rock") inventory.rock = true;

            else if (this.tag == "Bino") inventory.bino = true;

            else if (this.tag == "Glass") inventory.glass = true;

            else if (this.tag == "Lights") inventory.lights = true;

            CheckSlots();
        }
    }

    void CheckSlots()
    {
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                //el item se agrega
                inventory.isFull[i] = true;
                Instantiate(item, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }
}
