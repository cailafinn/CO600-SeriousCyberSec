using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;
public class TextBoxController : MonoBehaviour
{
    public Image leftSprite;
    public Image rightSprite;
    public TextMeshProUGUI text;

    private string[] story = new string[]{"You must be Ginny, you called my office about a hacking?", "Yes. That is correct. Someone took control of the house!", "We had all these improvements installed and they just went haywire last night.", "Interesting, I'll have a look around and see what I can find.", "Once I've gained enough INTUITION, I should be able to work out what really happened here.", "You are supposed to be the best in the business, I hope you live up to your REPUTATION.", "Of course Ma'am, I'll have this case cracked in no time!", "(I should make sure my deductions are correct. Too many errors and I'll be fired!)", "Best of luck to you, Sherry.", ""};
    private List<bool[]> focuses = new List<bool[]> {new bool[] {true,false}, new bool[] {false, true}, new bool[] {false, true}, new bool[] {true,false}, new bool[] {true,false}, new bool[] {false,true}, new bool[] {true,false}, new bool[] {true,false}, new bool[] {false,true}, new bool[] {false, false}};
    
    private int currentLine = 0;

    public bool open = false;

    private SherryMovement playerMovement;
    public void Interact() {
        playerMovement = GameObject.Find("sherry_b1(Clone)").GetComponent<SherryMovement>();
        if (!open) {
            playerMovement.enabled = false;
            Focus(focuses[currentLine][0], focuses[currentLine][1]);
            StartCoroutine("Write");
        }
    }

    public void NextText() {
        StopAllCoroutines();
        currentLine++;
        Focus(focuses[currentLine][0], focuses[currentLine][1]);
        StartCoroutine("Write");
        if (currentLine == story.Length-1) {
            GameObject.Find("TextBox").SetActive(false);
            open = false;
            playerMovement.enabled = true;
            currentLine = 0;
        }
    }

    IEnumerator Write() {
        text.text = "";
        foreach (char c in story[currentLine]) {
            text.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }
    void Focus(bool leftFocus, bool rightFocus) {
        if (leftFocus) {
            leftSprite.color = new Color(1, 1, 1);
        } else {
            leftSprite.color = new Color(0.25f, 0.25f, 0.25f);
        }
        if (rightFocus) {
            rightSprite.color = new Color(1, 1, 1);
        } else {
            rightSprite.color = new Color(0.25f, 0.25f, 0.25f);
        }
    }
}
