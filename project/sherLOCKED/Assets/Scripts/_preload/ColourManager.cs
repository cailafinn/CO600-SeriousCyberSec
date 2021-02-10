using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public static ColourManager Instance { get; private set;}

    public RuntimeAnimatorController[] controllers;

    private RuntimeAnimatorController currentController;

    private string currentColour;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    void Start() {
        currentController = controllers[0];
        currentColour = "grey";
    }

    public void SetColour(string colour) {
        if (colour == "grey") {
            currentController = controllers[0];
            currentColour = colour;
        } else if (colour == "red") {
            currentController = controllers[1];
            currentColour = colour;
        } else if (colour == "green") {
            currentController = controllers[2];
            currentColour = colour;
        } else if (colour == "blue") {
            currentController = controllers[3];
            currentColour = colour;
        } else {
            Debug.Log("Error: Invalid colour controller selected. 'grey', 'red', 'green', or 'blue' are the only valid options.");
        }
    }
    
    public RuntimeAnimatorController GetCurrentController() {
        return currentController;
    }

    public string GetCurrentColour() {
        return currentColour;
    }
}
