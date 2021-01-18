using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1Qs : MonoBehaviour
{
    // Public Variables
    public Text question;
    public Image yesButton;
    public Image noButton;
    public Image noButton2;
    public Text extraInfo;

    public SherryProgress prog;
    
    // Private Variables
    private GameObject[] questionObjects;
    private bool inCollider = false;
    private bool answered = false;
    private string[] questions = new string[] {
        "I need to see what went wrong with the security in the house. I need to define the CIA triad – now what does it stand for?",
        "Let's look at confidentiality. Before I can find any clues that link to it, I need to define it. Select the definition of confidentiality",
        "Looking at this clue here reminds me of an element from the CIA triad, the definition of it is, 'it prevents unauthorised modification of data and systems' but which one of the elements does it belong to?",
        "This clue is fascinating I think it's to do with the availability element of the CIA triad. I should check by looking at the definition. Select the definition of availability",
        "Hmmm, it looks like the victim, Ginny, had granted someone permission to access a file, what is the name of this process?",
        "I wonder if the hacker managed to gain authentication? Select the definition of authentication",
        "This clue looks linked to the factor Non-repudiation to me. Select the definition of non-repudiation",
        "This clue shows we should think about the computer security of this mansion. Select which of the following could be used to describe computer security",
        "Hmmm let's look at cyber security in more detail. The collection of what can be used to protect the cyber environment, organisation and user's assets?",
        "This clue seems to point in the direction of computer security. Which of the following can be used to describe what computer security is?"
    };
    private string[] correctAnswers = new string[] {
        "Confidentiality, Integrity, Availability",
        "preventing unauthorized disclosure of information. Includes secrecy, privacy",
        "Integrity",
        "preventing downtime of systems or inability to access data/information",
        "Authorisation",
        "the process of confirming the truth or correctness of the claimed artefact or identity",
        "ability for parties to prove that a message has been sent by a specific person, and received by a specific person. Therefore neither party can claim they did not send/receive the message.",
        "A measure of how well a system resists misuse from either an insider or an outsider",
        "Collection of tools, policies, security concepts, security safeguards, guidelines, risk management approaches, actions, training, best practices, assurance and technologies",
        "Freedom from undesirable events in a system, either accidental or malicious"
    };
    private string[] wrongAnswers = new string[] {
        "Confidentiality, Identity, Acceptability", 
        "Competence, Identity, Availability",
        "preventing downtime of systems or inability to access data/information",
        "preventing unauthorized modification of data and systems",
        "Availability",
        "Identity",
        "preventing unauthorized modification of data and systems",
        "preventing unauthorized disclosure of information. Includes secrecy, privacy",
        "Authentication",
        "Apple bobbing",
        "the process of granting permission to someone/thing to do some action (e.g., access files)",
        "the process of hanging a picture on the wall",
        "the process of granting permission to someone/thing to do some action (e.g., access files)",
        "the process of confirming the truth or correctness of the claimed artefact or identity",
        "An apple a day keeps the doctor away",
        "A measure of how well a system stores files",
        "Collection of connected computing devices, personnel, infrastructure, applications, services, telecommunications systems",
        "Collection of scout badges",
        "Freedom from desirable events in a system, either accidental or malicious",
        "Freedom from desirable events in a computer, either accidental or malicious"
    };

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
            extraInfo.text = "Correct! The answer is " + yesButton.GetComponentInChildren<Text>().text;  
            answered = true;
            prog.IncreaseIntuition(10);
        }
    }

    public void Incorrect() {
        if (!answered) {
            noButton.color = Color.red;
            extraInfo.text = "Incorrect. The answer is " + yesButton.GetComponentInChildren<Text>().text;
            answered = true;
            prog.DecreaseReputation(10);
        }
    }

    public void Incorrect2() {
        if (!answered) {
            noButton2.color = Color.red;
            extraInfo.text = "Incorrect. The answer is " + yesButton.GetComponentInChildren<Text>().text;
            answered = true;
            prog.DecreaseReputation(10);
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
            PickQuestion();
            g.SetActive(true);
        }
    }

    // Hides objects with the ShowAfterInteraction tag
    private void HideQuestion() {
        foreach (GameObject g in questionObjects) {
            g.SetActive(false);
        }
    }

    // Picks question and answers depending what object and room
    void PickQuestion() {
        // Create a temporary reference of the current room
        Scene currentRoom = SceneManager.GetActiveScene ();
        // Get the name of this room
        string roomName = currentRoom.name;
        if(roomName == "Hall" && this.name == "desk") {
            question.text = questions[0];
            yesButton.GetComponentInChildren<Text>().text = correctAnswers[0];
            noButton.GetComponentInChildren<Text>().text = wrongAnswers[0];
            noButton2.GetComponentInChildren<Text>().text = wrongAnswers[1];
        }
        else if(roomName == "Hall" && this.name == "cardboardBox (1)") {
            question.text = questions[9];
            yesButton.GetComponentInChildren<Text>().text = correctAnswers[9];
            noButton.GetComponentInChildren<Text>().text = wrongAnswers[18];
            noButton2.GetComponentInChildren<Text>().text = wrongAnswers[19];
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
