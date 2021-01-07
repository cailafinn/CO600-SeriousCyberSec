using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    public GameObject interact;
    private bool inCollider = false;
    public string DestinationRoomName;
    public string DestinationGameObjectName;

    void Start() {
        interact.SetActive(false);
    }

    // checks if player is near object
    // if they are near the object, text appears
    // prompting user to interact with object
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable") && !inCollider)
        {
            inCollider = true;
            Application.LoadLevel(DiningRoom);
            interact.SetActive(true);
        }
    }

    // checks if player leaves the object perimeter
    // if player does leave the perimeter text prompt is removed
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactable"))
        {
            inCollider = false;
            interact.SetActive(false);
        
}