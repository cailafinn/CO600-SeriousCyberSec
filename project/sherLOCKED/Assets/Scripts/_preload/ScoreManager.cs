using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set;}

    public int currentRep = 50;
    public int currentInt = 0;

    private int maxInt = 100;
    private int maxRep = 50;
    private int nextInt = 10;

    private DateTime levelStart;

    private TimeSpan levelTime;

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
            LevelEnd();
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        } else if (currentInt >= maxInt){
            LevelEnd();
            UnityEngine.SceneManagement.SceneManager.LoadScene("LevelEnd");
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
        levelStart = DateTime.Now;
        levelTime = TimeSpan.Zero;
        currentInt = 0;
        currentRep = maxRep;
        GameObject.Find("ReputationBar").GetComponent<ProgressBar>().SetValue(currentRep);
        GameObject.Find("IntuitionBar").GetComponent<ProgressBar>().SetValue(currentInt);
    }

    private void LevelEnd() {
        levelTime = DateTime.Now - levelStart;
    }
}
