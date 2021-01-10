using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherryProgress : MonoBehaviour
{
    // UI elements
    public ProgBar intuitionBar;
    public ProgBar reputationBar;

    // Intution, increaced by correct answers
    private int currentIntuition;
    private int maxIntuition = 100;

    // Reputation, decreaced by incorrect answers
    private int currentReputation;
    private int maxReputation = 100;

    // Start is called before the first frame update
    void Start()
    {
        currentIntuition = 0;
        currentReputation = 100;
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
    public void ReduceReputation(int reduce) {
        currentReputation -= reduce;
        reputationBar.SetValue(currentReputation);
    }

    // Increace intuition when question is correctly answered
    public void IncreaceIntuition(int increace) {
        currentIntuition += increace;
        intuitionBar.SetValue(currentIntuition);
    }



    
}
