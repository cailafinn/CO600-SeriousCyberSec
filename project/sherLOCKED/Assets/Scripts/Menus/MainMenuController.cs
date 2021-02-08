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

    public void Start() {
        SetLevelColours();
        howToMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(true);
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

    // Return to the main menu. 
    public void Back() {
        howToMenu.SetActive(false);
        levelSelectMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void level1() {
        LevelManager.Instance.SetCurrentLevel(1);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        SceneManager.LoadScene("Hall");
    }

    public void level2() {
        LevelManager.Instance.SetCurrentLevel(2);
        ScoreManager.Instance.Reset();
        UIManager.Instance.SetGameUIVisible(true);
        SceneManager.LoadScene("ServerRoom");
    }

    public void level3() {

    }

    public void level4() {

    }

    public void level5() {

    }

    private void SetLevelColours() {
        var buttons = GameObject.FindGameObjectsWithTag("LevelButton");
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
