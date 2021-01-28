using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.Collections;

public class DoorInteraction : MonoBehaviour
{
    private bool inCollider = false;
    Vector3 playerPos;
    // private Animator facing;
    
    void Start() {
    }

    // checks if player is near a door
    // if they go through the door
    // load new room
    // player object is not deleted when the new room is loaded
    void OnTriggerEnter2D(Collider2D other)
    {
        // Create a temporary reference of the current room
         Scene currentRoom = SceneManager.GetActiveScene ();
         // Get the name of this room
         string roomName = currentRoom.name;

         // Number of player objects in room
         var numOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;

         // for setting the player facing north -> for future use
         // facing = other.gameObject.GetComponent<Animator>();

         if (other.gameObject.CompareTag("Player") && !inCollider) {
             if(roomName == "Hall" && this.name == "library_door")
             {
                //setting player postion after they go through a door 
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("Library");
                playerPos = transform.position;
                playerPos.x = 4;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
                // attempting to get sherry facing foward -> for future reference
                // facing.SetFloat("input_y", -facing.GetFloat("input_y"));
                // Time.timeScale = 1;

                other.gameObject.SetActive(true);
            }
            else if(roomName == "Hall" && this.name == "dining_door")
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("DiningRoom");
                playerPos = transform.position;
                playerPos.x = -3;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
                other.gameObject.SetActive(true);                
            }
            else if(roomName == "DiningRoom" && this.name == "hall_door")
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("Hall");
                playerPos = transform.position;
                playerPos.x = 4;
                playerPos.y = 3;
                other.gameObject.transform.position = playerPos;
                other.gameObject.SetActive(true);
            }
            else if(roomName == "DiningRoom" && this.name == "ballroom_door")
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("Ballroom");
                playerPos = transform.position;
                playerPos.x = -5;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
                other.gameObject.SetActive(true);
            }
            else if(roomName == "Library" && this.name == "hall_door")
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("Hall");
                playerPos = transform.position;
                playerPos.x = -2;
                playerPos.y = 3;
                other.gameObject.transform.position = playerPos;
                other.gameObject.SetActive(true);
            }
            else if(roomName == "Ballroom" && this.name == "dining_door")
            {
                other.gameObject.SetActive(false);
                SceneManager.LoadScene("DiningRoom");
                playerPos = transform.position;
                playerPos.x = 3;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
                other.gameObject.SetActive(true);
            }

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
