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

    private int correctAnswers = 0;

    private DateTime levelStart;
    private TimeSpan levelTime;

    private bool won = false;

    private bool playing = true;

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
        if(playing) {
            if (currentRep <= 0) {
                LevelEnd();
            } else if (currentInt >= maxInt){
                won = true;
                LevelEnd();
            }
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
        correctAnswers++;
        GameObject.Find("IntuitionBar").GetComponent<ProgressBar>().SetValue(currentInt);
    }

    public TimeSpan GetLevelTime() {
        return levelTime;
    }

    public int GetCorrectAnswers() {
        return correctAnswers;
    }

    public bool GetWon() {
        return won;
    }

    public void Reset() {
        Time.timeScale = 1;
        playing = true;
        levelStart = DateTime.Now;
        levelTime = TimeSpan.Zero;
        correctAnswers = 0;
        currentInt = 0;
        currentRep = maxRep;
        UIManager.Instance.ResetValues();
    }

    private void LevelEnd() {
        UIManager.Instance.SetGameUIVisible(false);
        playing = false;
        levelTime = DateTime.Now.Subtract(levelStart);
        Destroy(GameObject.Find("sherry_b1(Clone)"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelEnd");
    }
}
