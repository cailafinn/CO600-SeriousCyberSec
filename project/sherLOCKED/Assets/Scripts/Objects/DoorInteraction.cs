using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class DoorInteraction : MonoBehaviour
{
    private bool inCollider = false;
    Vector3 playerPos;

    void Start() {

    }

    // checks if player is near a door
    // if they go through the door
    // load new room
    // player object is not deleted when the new room is loaded
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !inCollider)
        {
            inCollider = true;
            DontDestroyOnLoad(other.gameObject);
            //setting player postion after they go through a door            
            playerPos = transform.position;
            playerPos.x = -3;
            playerPos.y = 2;
            other.gameObject.transform.position = playerPos;
            SceneManager.LoadScene("DiningRoom");
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
