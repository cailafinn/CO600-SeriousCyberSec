using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SherryInteract : MonoBehaviour
{
    public Text interact;
    private bool inCollider = false;

    void Update()
    {
        if (inCollider)
        {
            if (Input.GetKeyDown("e") || Input.GetKeyDown("space"))
            {
                interact.text = "Good Job. You did it!";
            }
        }
    }

    // checks if player is near object
    // if they are near the object, text appears
    // prompting user to interact with object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable") && !inCollider)
        {
            inCollider = true;
            interact.text = "Press E or Space to interact with the computer.";
        }
    }

    // checks if player leaves the object perimeter
    // if player does leave the perimeter text prompt is removed
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            inCollider = false;
            interact.text = "";
        }
    }

}
