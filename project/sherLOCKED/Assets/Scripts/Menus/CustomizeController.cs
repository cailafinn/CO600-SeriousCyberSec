using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomizeController : MonoBehaviour
{
    public TextMeshProUGUI text; 

    public void Start() {
        UpdateText();
    }

    public void SetGrey() {
        ColourManager.Instance.SetColour("grey");
        UpdateText();
    }

    public void SetRed() {
        ColourManager.Instance.SetColour("red");
        UpdateText();
    }

    public void SetGreen() {
        ColourManager.Instance.SetColour("green");
        UpdateText();
    }

    public void SetBlue() {
        ColourManager.Instance.SetColour("blue");
        UpdateText();
    }

    private void UpdateText() {
        text.text = "Current Colour: " + ColourManager.Instance.GetCurrentColour();
    }
}
