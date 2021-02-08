using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource MusicSource;

    public static MusicManager Instance { get; private set;}

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public void PlayMusic(AudioClip clip) {
        MusicSource.clip = clip;
        MusicSource.Play();
    }
}
