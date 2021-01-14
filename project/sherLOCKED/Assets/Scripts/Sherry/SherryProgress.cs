using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherryProgress : MonoBehaviour
{
    // UI elements
    public ProgressBar intuitionBar;
    public ProgressBar reputationBar;

    // Intution, increaced by correct answers
    private int currentIntuition;
    public int maxIntuition = 100;

    // Reputation, decreaced by incorrect answers
    private int currentReputation;
    public int maxReputation = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentIntuition = 0;
        intuitionBar.SetValue(currentIntuition);
        currentReputation = 100;
        reputationBar.SetValue(currentReputation);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentReputation <= 0) {
            print("LOSE!");
        }
        if (currentIntuition >= maxIntuition) {
            print("WIN!");
        }
    }

    // Reduce rep when a question is incorrectly answered
    public void DecreaceReputation(int value) {
        currentReputation -= value;
        reputationBar.SetValue(currentReputation);
    }

    // Increace intuition when question is correctly answered
    public void IncreaceIntuition(int value) {
        currentIntuition += value;
        intuitionBar.SetValue(currentIntuition);
    }



    
}
