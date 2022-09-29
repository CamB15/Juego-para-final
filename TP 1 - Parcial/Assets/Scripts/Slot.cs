using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private inventory inv;
    public int i;
    void Start()
    {
        inv = GameObject.FindGameObjectWithTag("Player").GetComponent<inventory>();
    }
    void Update()
    {
        if (transform.childCount <= 0)
        {
            inv.isFull[i] = false;
        }
    }
}
