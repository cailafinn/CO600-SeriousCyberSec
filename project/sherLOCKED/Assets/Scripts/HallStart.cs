using UnityEngine;
using System.Collections;
using UnityEditor;

public class HallStart : MonoBehaviour
{
    // Reference to the Sherry prefab
    public GameObject sherryPrefab;

    public GameObject introText;

    void Start() {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0) {
            // Instantiate player when the game is loaded
            var sherry = Instantiate(sherryPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            sherry.transform.tag = "Player";
            sherry.GetComponent<Renderer>().sortingLayerName = "character";
            sherry.GetComponent<Renderer>().sortingOrder = 0;
            sherry.GetComponent<Animator>().runtimeAnimatorController = ColourManager.Instance.GetCurrentController();

            // putting this in the if as a hack to make it happen just once
            introText.SetActive(true);
            introText.GetComponent<TextBoxController>().Interact();
        }
    }
}
