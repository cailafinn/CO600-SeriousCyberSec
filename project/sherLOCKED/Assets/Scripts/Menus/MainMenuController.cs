using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToMenu;
    public GameObject levelSelectMenu;

    public void Start() {
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
        SceneManager.LoadScene("PreHall");
    }

    public void level2() {
        
    }

    public void level3() {

    }

    public void level4() {

    }

    public void level5() {

    }
}
