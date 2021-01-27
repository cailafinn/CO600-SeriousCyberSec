using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelEnd : MonoBehaviour
{
    public GameObject fail;
    public GameObject succeed;

    public TextMeshProUGUI correctAnswers;
    public TextMeshProUGUI levelTime;

    void Awake()
    {
        if (ScoreManager.Instance.GetWon()) {
            fail.SetActive(false);
            succeed.SetActive(true);
        } else {
            fail.SetActive(true);
            succeed.SetActive(false);
        }
        correctAnswers.text = ScoreManager.Instance.GetCorrectAnswers() + "/10";
        levelTime.text = ScoreManager.Instance.GetLevelTime().Hours + ":" + ScoreManager.Instance.GetLevelTime().Minutes + ":" + ScoreManager.Instance.GetLevelTime().Seconds;
    }
}
