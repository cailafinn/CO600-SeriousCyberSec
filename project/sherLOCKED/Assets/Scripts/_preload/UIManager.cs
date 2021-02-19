using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set;}

    public GameObject canvas;
    
    private GameObject intuitionBar;
    private GameObject reputationBar;
    private GameObject interactionSymbol;
    private GameObject pauseMenu;

    // Page the main menu should start on.
    private string mainMenuPage = "MainMenu";


    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        intuitionBar = GameObject.Find("IntuitionBar");
        reputationBar = GameObject.Find("ReputationBar");
        interactionSymbol = GameObject.Find("interactionSymbol");
        pauseMenu = GameObject.Find("PauseMenu");
        SetGameUIVisible(false);
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Debug.Log("Warning: multiple " + this + " in scene!");
        }
    }

    public void SetGameUIVisible(bool visible) {
        canvas.SetActive(visible);
        pauseMenu.GetComponent<PauseMenuController>().enabled = visible;
        pauseMenu.GetComponent<PauseMenuController>().HidePause();
    }

    public void ResetValues() {
        intuitionBar.GetComponent<ProgressBar>().SetValue(0);
        reputationBar.GetComponent<ProgressBar>().SetValue(50);
    }

    public void SetInteractionVisible(bool visible) {
        interactionSymbol.SetActive(visible);
    }

    public void SetMainMenuPage(string setTo) {
        mainMenuPage = setTo;
    }

    public string GetMainMenuPage() {
        return mainMenuPage;
    }

}
