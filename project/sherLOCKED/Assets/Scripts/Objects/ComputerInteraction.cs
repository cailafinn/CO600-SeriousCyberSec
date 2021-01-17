using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerInteraction : MonoBehaviour
{
    // Public Variables
    public Image yesButton;
    public Image noButton;
    public Text extraInfo;

    public SherryProgress prog;
    
    // Private Variables
    private GameObject[] questionObjects;
    private bool inCollider = false;
    private bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        questionObjects = GameObject.FindGameObjectsWithTag("ShowAfterInteraction");
        HideQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        if (inCollider)
        {
            if (Input.GetKeyDown("e") || Input.GetKeyDown("space"))
            {
                Time.timeScale = 0;
                ShowQuestion();
            }
        }
    }

    public void Correct() {
        if(!answered) {
            yesButton.color = Color.green;
            extraInfo.text = "Correct! This question is working.";
            answered = true;
            prog.IncreaceIntuition(10);
        }
    }

    public void Incorrect() {
        if (!answered) {
            noButton.color = Color.red;
            extraInfo.text = "Incorrect. This question is working.";
            answered = true;
            prog.DecreaceReputation(10);
        }
    }

    // Resume the scene 
	public void Resume() {
         if (Time.timeScale == 0){
				Time.timeScale = 1;
                HideQuestion();
			}
	}

    // Shows objects with the ShowAfterInteraction tag
    private void ShowQuestion() {
        foreach (GameObject g in questionObjects) {
            g.SetActive(true);
        }
    }

    // Hides objects with the ShowAfterInteraction tag
    private void HideQuestion() {
        foreach (GameObject g in questionObjects) {
            g.SetActive(false);
        }
    }
    
    // checks if player is near object
    // if they are near the object, text appears
    // prompting user to interact with object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !inCollider)
        {
            inCollider = true;
            prog = other.gameObject.GetComponent<SherryProgress>();
        }
    }

    // checks if player leaves the object perimeter
    // if player does leave the perimeter text prompt is removed
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inCollider = false;
        }
    }
}
