using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // Singleton instance accessor
    public static QuestionManager Instance { get; private set;}
    
    private List<string> interacted = new List<string>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public bool IsAnswered(string toCheck) {
        return interacted.Contains(toCheck);
    }

    public bool AreAllAnswered() {
        return interacted.Count >= 10;
    }

    public void ClearList() {
        interacted.Clear();
    }

    public void AddAnswered(string toAdd) {
        interacted.Add(toAdd);
    }
}
