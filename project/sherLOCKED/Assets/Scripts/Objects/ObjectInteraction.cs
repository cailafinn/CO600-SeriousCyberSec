using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    // Public Variables
    public Image topAnswer;
    public Image middleAnswer;
    public Image bottomAnswer;
    public Image correctAnswer;
    
    public TextMeshProUGUI extraInfo;
    public GameObject questionUI;

    private ScoreManager prog;
    
    // Private Variables
    private bool inCollider = false;
    private bool answered = false;

    // Start is called before the first frame update
    void Start()
    {
        HideQuestion();
        prog = ScoreManager.Instance;
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
            correctAnswer.color = Color.green;
            extraInfo.text = "That's it! Time to move on...";
            answered = true;
            prog.IncreaseIntuition();
        }
    }

    public void Incorrect(Button button) {
        if (!answered) {
            correctAnswer.color = Color.green;
            button.GetComponent<Image>().color = Color.red;
            extraInfo.text = "Whoops, my mistake. I hope Ginny didn't see that...";
            answered = true;
            prog.DecreaseReputation();
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
        questionUI.SetActive(true);
    }

    // Hides objects with the ShowAfterInteraction tag
    private void HideQuestion() {
        questionUI.SetActive(false);
    }
    
    // checks if player is near object
    // if they are near the object, text appears
    // prompting user to interact with object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !inCollider)
        {
            inCollider = true;
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
