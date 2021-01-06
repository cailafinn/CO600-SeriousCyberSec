using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToMenu;

    public void Start() {
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Start the game
    public void PlayGame() {
        SceneManager.LoadScene("Hall");
    }

    // Show the controls and hide the main menu
    public void HowToPlay() {
        mainMenu.SetActive(false);
        howToMenu.SetActive(true);
    }

    // Return to the main menu from the controls. 
    public void Back() {
        howToMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
