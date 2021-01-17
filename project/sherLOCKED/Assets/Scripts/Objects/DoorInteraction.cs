using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;
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

        // // Get the name of the door
        // string doorName = 
        
        // Number of player objects in room
        var numOfPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        // for setting the player facing north
        // facing = other.gameObject.GetComponent<Animator>();

        if (other.gameObject.CompareTag("Player") && !inCollider)
        {
            Debug.Log( "collide (name) : " + GameObject.Find("dining_door") );
            inCollider = true;

            if(roomName == "Hall" && this.name == "library_door")
            {
                //setting player postion after they go through a door 
                SceneManager.LoadScene("Library");           
                playerPos = transform.position;
                playerPos.x = 4;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;

                // attempting to get sherry facing foward -> for future reference
                // facing.SetFloat("input_y", -facing.GetFloat("input_y"));
                // Time.timeScale = 1;

            }
            else if(roomName == "Hall" && this.name == "dining_door")
            {
                SceneManager.LoadScene("DiningRoom");           
                playerPos = transform.position;
                playerPos.x = -3;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
            }
            else if(roomName == "DiningRoom" && this.name == "hall_door")
            {
                SceneManager.LoadScene("Hall");          
                playerPos = transform.position;
                playerPos.x = 4;
                playerPos.y = 3;
                other.gameObject.transform.position = playerPos;

                // attempting to get sherry facing foward -> for future reference
                // facing.SetFloat("input_y", -facing.GetFloat("input_y"));
                // Time.timeScale = 1; 
            }
            else if(roomName == "DiningRoom" && this.name == "ballroom_door")
            {
                SceneManager.LoadScene("Ballroom");          
                playerPos = transform.position;
                playerPos.x = 3;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;

                // attempting to get sherry facing foward -> for future reference
                // facing.SetFloat("input_y", -facing.GetFloat("input_y"));
                // Time.timeScale = 1; 
            }
            else if(roomName == "Library" && this.name == "hall_door")
            {
                SceneManager.LoadScene("Hall");          
                playerPos = transform.position;
                playerPos.x = -2;
                playerPos.y = 3;
                other.gameObject.transform.position = playerPos;
            }
            else if(roomName == "Ballroom" && this.name == "dining_door")
            {
                SceneManager.LoadScene("DiningRoom");          
                playerPos = transform.position;
                playerPos.x = 3;
                playerPos.y = 2;
                other.gameObject.transform.position = playerPos;
            }


            // Only destroy the player when loading the new scene if the player already exists
            if(numOfPlayers == 1) {
                DontDestroyOnLoad(other.gameObject);
            }
            else {
                Destroy(other.gameObject);
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
