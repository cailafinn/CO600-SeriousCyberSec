using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SherryInteract : MonoBehaviour
{
    public Text interact;
    private bool inCollider = false;
    private Rigidbody2D rb2d;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

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
