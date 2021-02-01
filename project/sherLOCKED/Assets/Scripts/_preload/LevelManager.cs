using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set;}
    private Dictionary<int, bool> levels = new Dictionary<int, bool>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    void Start() {
        levels.Add(1, false);
        levels.Add(2, false);
        levels.Add(3, false);
        levels.Add(4, false);
        levels.Add(5, false);
    }

    public bool GetComplete(int level) {
        return levels[level];
    }

    public void SetComplete(int level) {
        levels[level] = true;
    }
}
