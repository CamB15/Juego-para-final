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

    void Start ()
    {
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
                digit3 = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                characters[0] = digits[10];
                characters[1] = digits[10];
                characters[2] = digit3;
                break;

            case 2:
                digit2 = Instantiate(characters[2], GameObject.FindGameObjectWithTag("char2").transform, false);
                digit3 = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                characters[0]= digits[10];
                characters[1] = digit2;
                characters[2] = digit3;
                break;

            case 3:
                digit1= Instantiate(characters[1], GameObject.FindGameObjectWithTag("char1").transform, false);
                digit2 = Instantiate(characters[2], GameObject.FindGameObjectWithTag("char2").transform, false);
                digit3 = Instantiate(digits[digitJustEntered], GameObject.FindGameObjectWithTag("char3").transform, false);
                characters[0] = digit1;
                characters[1] = digit2;
                characters[2] = digit3; 
                break;
        }
    }

    private void CheckResults()
    {
        if (codeSequence == "793")
        {
            print("Correct");
        }
        else
        {
            print("Incorrect");
            ResetDisplay();
        }
    }

    private void ResetDisplay()
    {
        //arreglar
        for (int i = 0; i < characters.Length; i++)
        {
            while(transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
        codeSequence = "";
    }
    private void OnDestroy()
    {
        Push_button.ButtonPressed -= AddDigitToCode;
    }
}
