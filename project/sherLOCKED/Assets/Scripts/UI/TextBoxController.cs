﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;
public class TextBoxController : MonoBehaviour
{
    public Image leftSprite;
    public Image rightSprite;
    public TextMeshProUGUI text;

    public string[] story = new string[0];
    public bool[] focusLeft = new bool[0];
    
    private int currentLine = 0;

    public bool open = false;

    private SherryMovement playerMovement;
    private NpcInteraction npcInteraction;

    public void Interact() {
        playerMovement = GameObject.Find("sherry_b1(Clone)").GetComponent<SherryMovement>();
        npcInteraction = GameObject.Find("ginny").GetComponent<NpcInteraction>();
        if (!open) {
            npcInteraction.enabled = false;
            playerMovement.enabled = false;
            Focus(focusLeft[currentLine]);
            StartCoroutine("Write");
        }
    }

    public void NextText() {
        StopAllCoroutines();
        currentLine++;
        Focus(focusLeft[currentLine]);
        StartCoroutine("Write");
        if (currentLine == story.Length-1) {
            open = false;
            playerMovement.enabled = true;
            npcInteraction.enabled = true;
            currentLine = 0;
            gameObject.SetActive(false);
        }
    }

    IEnumerator Write() {
        text.text = "";
        foreach (char c in story[currentLine]) {
            text.text += c;
            yield return new WaitForSeconds(0.02f);
        }
    }

    void Focus(bool leftFocus) {
        if (leftFocus) {
            leftSprite.color = new Color(1, 1, 1);
            rightSprite.color = new Color(0.25f, 0.25f, 0.25f);
        } else {
            leftSprite.color = new Color(0.25f, 0.25f, 0.25f);
            rightSprite.color = new Color(1, 1, 1);
        }
    }
}
