using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad_active : MonoBehaviour
{
    [SerializeField] private GameObject keypad;
    [SerializeField] private GameObject screen;
    public GameObject mark;
    public GameObject nums; 
    public GameObject display;
    public bool active = true;
    private bool inRange;
    private bool flipflop = false;
    public BoxCollider2D cp;

    void Start ()
    {
        cp = GetComponent<BoxCollider2D>();
    }
    void Update ()
    {
        if (inRange && Input.GetButtonDown("Keypad"))
        {
            if(active)
            {
                if (flipflop == false)
                {
                    nums = Instantiate(keypad, GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    display = Instantiate(screen, GameObject.FindGameObjectWithTag("Canvas").transform, false);
                    flipflop = !flipflop;
                }
                else
                {
                    Destroy(nums);
                    Destroy(display);
                    flipflop = !flipflop;
                }
            }
            else if (!active)
            { }
        }
        
    }

    void OnTriggerEnter2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = true;
            mark.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D collission)
    {
        if (collission.CompareTag("Player"))
        {
            inRange = false;
            mark.SetActive(false);
        }
    }

}
