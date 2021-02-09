using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourManager : MonoBehaviour
{
    public static ColourManager Instance { get; private set;}

    public RuntimeAnimatorController[] controllers;

    private RuntimeAnimatorController currentController;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    void Start() {
        currentController = controllers[1];
    }

    public void SetColour(string colour) {
        if (colour == "grey") {
            currentController = controllers[0];
        } else if (colour == "red") {
            currentController = controllers[1];
        } else if (colour == "green") {
            currentController = controllers[2];
        } else if (colour == "blue") {
            currentController = controllers[3];
        } else {
            Debug.Log("Error: Invalid colour controller selected. 'grey', 'red', 'green', or 'blue' are the only valid options.");
        }
    }
    
    public RuntimeAnimatorController GetCurrentController() {
        return currentController;
    }
}
