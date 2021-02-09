using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeController : MonoBehaviour
{
    public void SetGrey() {
        ColourManager.Instance.SetColour("grey");
    }

    public void SetRed() {
        ColourManager.Instance.SetColour("red");
    }

    public void SetGreen() {
        ColourManager.Instance.SetColour("green");
    }

    public void SetBlue() {
        ColourManager.Instance.SetColour("blue");
    }
}
