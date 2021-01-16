using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcInteraction : MonoBehaviour
{

    private bool inCollider = false;
    private GameObject player;

    // Update is called once per frame
    void Update() {
        if (inCollider) {
            if (Input.GetKeyDown("e") || Input.GetKeyDown("space")) {
                Time.timeScale = 0;
                Interact();
            }
        }
    }

    // Things that happen after the npc is interacted with
    void Interact() {
        Animator anim = GetComponent<Animator>();
        anim.SetFloat("input_x", -player.GetComponent<Animator>().GetFloat("input_x"));
        anim.SetFloat("input_y", -player.GetComponent<Animator>().GetFloat("input_y"));
        Time.timeScale = 1;
    }
    
    // Check if the player enters the npc perimiter
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player") && !inCollider)
        {
            inCollider = true;
            player = other.gameObject;
        }
    }

    // checks if player leaves the npc perimeter
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            inCollider = false;
            player = null;
        }
    }
}
