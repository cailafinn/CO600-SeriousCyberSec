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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable") && !inCollider)
        {
            inCollider = !inCollider;
            interact.text = "Press E or Space to interact with the desk.";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            inCollider = !inCollider;
            interact.text = "";
        }
    }

}
