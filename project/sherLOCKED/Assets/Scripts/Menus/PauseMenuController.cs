using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject canvas;
    void Update() {
        if (Input.GetKeyDown("escape")) {
            if(canvas.activeSelf) {
                HidePause();
            } else {
                ShowPause();
            }
        }
    }

    public void HidePause() {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }

    public void ShowPause() {
        canvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void ReturnToMainMenu() {
        UIManager.Instance.SetGameUIVisible(false);
        Destroy(GameObject.Find("sherry_b1(Clone)"));
        SceneManager.LoadScene("MainMenu");
    }
}
