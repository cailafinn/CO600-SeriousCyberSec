﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}

    public GameObject canvas;
    
    private GameObject intuitionBar;
    private GameObject reputationBar;


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        intuitionBar = GameObject.Find("IntuitionBar");
        reputationBar = GameObject.Find("ReputationBar");
        SetGameUIVisible(false);
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public void SetGameUIVisible(bool visible) {
        canvas.SetActive(visible);
    }

    public void ResetValues() {
        intuitionBar.GetComponent<ProgressBar>().SetValue(0);
        reputationBar.GetComponent<ProgressBar>().SetValue(50);
    }

}
