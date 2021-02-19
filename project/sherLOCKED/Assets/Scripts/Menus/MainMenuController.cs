using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToMenu;
    public GameObject levelSelectMenu;
    public GameObject customizeMenu;
    public GameObject creditsMenu;

    public GameObject[] buttons;

    public void Start() {
        MusicManager.Instance.PlayMenuMusic();
        SetLevelColours();
        var page = UIManager.Instance.GetMainMenuPage();
        Back();
        if (page == "LevelSelect") {
            PlayGame();
        }
    }

    // Start the game
    public void PlayGame() {
        mainMenu.SetActive(false);
        levelSelectMenu.SetActive(true);
    }

    // Show the controls and hide the main menu
    public void HowToPlay() {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    public void Customize() {
        mainMenu.SetActive(false);
        customizeMenu.SetActive(true);
    }

    public void Credits() {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    // Return to the main menu. 
    public void Back() {
        howToMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        customizeMenu.SetActive(false);
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void level1() {
        LevelManager.Instance.SetCurrentLevel(1);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        MusicManager.Instance.PlayGameMusic();
        SceneManager.LoadScene("Hall");
    }

    public void level2() {
        LevelManager.Instance.SetCurrentLevel(2);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        MusicManager.Instance.PlayGameMusic();
        SceneManager.LoadScene("ServerRoom");
    }

    public void level3() {
        LevelManager.Instance.SetCurrentLevel(3);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        MusicManager.Instance.PlayGameMusic();
        SceneManager.LoadScene("Hall_case3");
    }

    public void level4() {
        LevelManager.Instance.SetCurrentLevel(4);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        MusicManager.Instance.PlayGameMusic();
        SceneManager.LoadScene("HallL4");
    }

    public void level5() {

    }

    private void SetLevelColours() {
        for(int i = 0; i<buttons.Length; i++) {
            ColorBlock cb = buttons[i].GetComponent<Button>().colors;
            if (LevelManager.Instance.GetComplete(i+1)) {
                cb.normalColor = new Color32(0, 132, 53, 255);               
            } else {
                cb.normalColor = new Color32(132, 0, 53, 255);               
            }
            buttons[i].GetComponent<Button>().colors = cb;
        }
    }
}
