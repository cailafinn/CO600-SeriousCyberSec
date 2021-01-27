using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SherryInteract : MonoBehaviour
{
    private bool inCollider = false;

    void Start() {
        UIManager.Instance.SetInteractionVisible(false);
    }

    // checks if player is near object
    // if they are near the object, text appears
    // prompting user to interact with object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable") && !inCollider && !QuestionManager.Instance.IsAnswered(other.gameObject.name))
        {
            inCollider = true;
            UIManager.Instance.SetInteractionVisible(true);
        }
    }

    // checks if player leaves the object perimeter
    // if player does leave the perimeter text prompt is removed
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            inCollider = false;
            UIManager.Instance.SetInteractionVisible(false);
        }
    }

}
