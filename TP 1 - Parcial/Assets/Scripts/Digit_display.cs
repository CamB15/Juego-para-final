using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Digit_display : MonoBehaviour
{
    [SerializeField] private GameObject [] digits;
    [SerializeField] private GameObject [] characters;
    private string codeSequence;
    private GameObject digit1;
    private GameObject digit2;
    private GameObject digit3;
    private Keypad_active active;
    [SerializeField] private GameObject prefab;

    void Start ()
    {
        active = GameObject.FindGameObjectWithTag("Box").GetComponent<Keypad_active>();
        codeSequence = "";
        for(int i = 0; i < characters.Length; i++)
        {
            characters[i]= digits[10];
        }
        Push_button.ButtonPressed += AddDigitToCode;
    }

    private void AddDigitToCode (string digitEntered)
    {
        if(codeSequence.Length < 3)
        {
            switch (digitEntered)
            {
                case "zero":
                    codeSequence += "0";
                    DisplayCodeSequence(0);
                    break;

                case "one":
                    codeSequence += "1";
                    DisplayCodeSequence(1);
                    break;

                case "two":
                    codeSequence += "2";
                    DisplayCodeSequence(2);
                    break;

                case "three":
                    codeSequence += "3";
                    DisplayCodeSequence(3);
                    break;

                case "four":
                    codeSequence += "4";
                    DisplayCodeSequence(4);
                    break;

                case "five":
                    codeSequence += "5";
                    DisplayCodeSequence(5);
                    break;

                case "six":
                    codeSequence += "6";
                    DisplayCodeSequence(6);
                    break;

                case "seven":
                    codeSequence += "7";
                    DisplayCodeSequence(7);
                    break;

                case "eight":
                    codeSequence += "8";
                    DisplayCodeSequence(8);
                    break;

                case "nine":
                    codeSequence += "9";
                    DisplayCodeSequence(9);
                    break;
            }
        }
            switch (digitEntered)
            {
            case "reset":

                ResetDisplay();
                break;

            case "ok":
                if(codeSequence.Length > 0)
                {
                    CheckResults();
                }
                break;
            }
    }
    
    private void DisplayCodeSequence(int digitJustEntered)
    {
        switch(codeSequence.Length)
        {
            case 1:
                characters[0] = digits[10];
                characters[1] = digits[10];
                characters[2] = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                break;

            case 2:
                digit2 = 
                characters[0]= digits[10];
                characters[1] = Instantiate(characters[2], GameObject.FindGameObjectWithTag("char2").transform, false);
                characters[2] = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                break;

            case 3:

                characters[0] = Instantiate(characters[1], GameObject.FindGameObjectWithTag("char1").transform, false);
                characters[1] = Instantiate(characters[2], GameObject.FindGameObjectWithTag("char2").transform, false);
                characters[2] = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == "793")
        {
            print("Correct");
            active.active = false;
            Destroy(active.nums);
            Destroy(active.display);
            Destroy(active.mark);
            Destroy(active.cp);
            Spawn();
        }
        else
        {
            print("Incorrect");
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        //destruye los numeros en pantalla de cada character
        for (int i = 0; i < characters.Length; i++)
        {
            while(GameObject.FindGameObjectWithTag("char1").transform.childCount > 0)
            {
                DestroyImmediate(GameObject.FindGameObjectWithTag("char1").transform.GetChild(0).gameObject);   
            }
            while (GameObject.FindGameObjectWithTag("char2").transform.childCount > 0)
            {
                DestroyImmediate(GameObject.FindGameObjectWithTag("char2").transform.GetChild(0).gameObject);
            }
            while (GameObject.FindGameObjectWithTag("char3").transform.childCount > 0)
            {
                DestroyImmediate(GameObject.FindGameObjectWithTag("char3").transform.GetChild(0).gameObject);
            }
        }
        codeSequence = "";
    }
    private void OnDestroy()
    {
        Push_button.ButtonPressed -= AddDigitToCode;
    }
    private void Spawn()
    {
        GameObject item = Instantiate(prefab) as GameObject;
        item.transform.position = new Vector2(-6.1f, -8.3f);
    }
}
