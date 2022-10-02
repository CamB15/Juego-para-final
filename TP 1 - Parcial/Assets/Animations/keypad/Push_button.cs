using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Push_button : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };
    private int deviderPosition;
    private string buttonName, buttonValue;

    void Start()
    {
        buttonName = gameObject.name;
        deviderPosition = buttonName.IndexOf("_");
        buttonValue = buttonName.Substring(0, deviderPosition);

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked ()
    {
        ButtonPressed(buttonValue);
    }
}
