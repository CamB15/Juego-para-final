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
            if (this.tag == "Rock") inventory.inInventory[0] = true;
            else if (this.tag == "Bino") inventory.inInventory[1] = true;
            else if (this.tag == "Glass") inventory.inInventory[2] = true;
            else if (this.tag == "Lights") inventory.inInventory[3] = true;
            else if (this.tag == "Wood") inventory.inInventory[4] = true;
            else if (this.tag == "Thread") inventory.inInventory[5] = true;
            else if (this.tag == "Ladder") inventory.inInventory[6] = true;
            else if (this.tag == "Tiger") inventory.inInventory[7] = true;
            else if (this.tag == "Key") inventory.inInventory[8] = true;

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
                inventory.clone = Instantiate(item, inventory.slots[i].transform, false);
                Destroy(gameObject);
                break;
            }
        }
    }
}
