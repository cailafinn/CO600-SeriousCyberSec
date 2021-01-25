using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    // Singleton instance accessor
    public static QuestionManager Instance { get; private set;}
    
    private List<GameObject> interacted = new List<GameObject>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public bool IsAnswered(GameObject toCheck) {
        return interacted.Contains(toCheck);
    }

    public void ClearList() {
        interacted.Clear();
    }

    public void AddAnswered(GameObject toAdd) {
        interacted.Add(toAdd);
    }
}
