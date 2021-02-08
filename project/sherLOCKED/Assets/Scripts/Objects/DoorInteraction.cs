using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    private bool inCollider = false;
    Vector3 playerPos;
    public string nextRoom;
    public float xPos;
    public float yPos;
    // private Animator facing;
    
    void Start() {
    }

    // checks if player is near a door
    // if they go through the door
    // load new room
    // player object is not deleted when the new room is loaded
    void OnTriggerEnter2D(Collider2D other)
    {
        // Number of player objects in room
        var numOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

        // for setting the player facing north -> for future use
        // facing = other.gameObject.GetComponent<Animator>();

        if (other.gameObject.CompareTag("Player") && !inCollider) {
            
            //setting player postion after they go through a door 
            other.gameObject.SetActive(false);
            SceneManager.LoadScene(nextRoom);
            playerPos = transform.position;
            playerPos.x = xPos;
            playerPos.y = yPos;
            other.gameObject.transform.position = playerPos;
            other.gameObject.SetActive(true);

            // Only destroy the player when loading the new scene if the player already exists
            if(numOfPlayers == 1) {
                DontDestroyOnLoad(other.gameObject);
                DontDestroyOnLoad(GameObject.Find("Canvas"));
            }
            else {
                Destroy(other.gameObject);
                // Destroy(other.gameObject);
                DontDestroyOnLoad(GameObject.Find("Canvas"));
            }
        }
    }
    // checks if player leaves the door perimeter
    // if player does leave the perimeter the set collider variable to false
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            inCollider = false;
        }
    }
}
