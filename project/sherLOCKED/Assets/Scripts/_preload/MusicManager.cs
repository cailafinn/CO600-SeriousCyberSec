using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    public static MusicManager Instance { get; private set;}

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public void PlayMenuMusic() {
        musicSource.pitch = 1.25f;
        musicSource.loop = true;
        PlayMusic(menuMusic);
    }

    public void PlayGameMusic() {
        musicSource.pitch = 1.0f;
        musicSource.loop = true;
        PlayMusic(gameMusic);
    }

    public void SetPitch(float pitch) {
        musicSource.pitch = pitch;
    }

    private void PlayMusic(AudioClip clip) {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
