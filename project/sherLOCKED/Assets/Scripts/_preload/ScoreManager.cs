using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set;}

    public int currentRep = 50;
    public int currentInt = 0;

    private int maxInt = 100;
    private int maxRep = 50;
    private int nextInt = 10;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (currentRep <= 0) {
            print("LOSE!");
        } else if (currentInt >= maxInt){
            print("WIN!");
        }
    }

    public void DecreaseReputation() {
        currentRep -= 10;
        nextInt += 10;
        GameObject.Find("ReputationBar").GetComponent<ProgressBar>().SetValue(currentRep);
    }

    public void IncreaseIntuition() {
        currentInt += nextInt;
        nextInt = 10;
        GameObject.Find("IntuitionBar").GetComponent<ProgressBar>().SetValue(currentInt);
    }

    public void Reset() {
        currentInt = 0;
        currentRep = maxRep;
        GameObject.Find("ReputationBar").GetComponent<ProgressBar>().SetValue(currentRep);
        GameObject.Find("IntuitionBar").GetComponent<ProgressBar>().SetValue(currentInt);
    }
}
