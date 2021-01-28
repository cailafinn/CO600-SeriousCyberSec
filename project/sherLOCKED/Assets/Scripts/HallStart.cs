using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;

public class HallStart : MonoBehaviour
{
    // Reference to the Sherry prefab
    public GameObject sherryPrefab;

    void Start() {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0) {
            // Instantiate player when the game is loaded
            var sherry = Instantiate(sherryPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            sherry.GetComponent<SherryProgress>().intuitionBar = GameObject.Find("IntuitionBar").GetComponent<ProgressBar>();  
            sherry.GetComponent<SherryProgress>().reputationBar = GameObject.Find("ReputationBar").GetComponent<ProgressBar>();
            sherry.transform.tag = "Player";
            sherry.GetComponent<Renderer>().sortingLayerName = "character";
            sherry.GetComponent<Renderer>().sortingOrder = 0;
        }
    }
}
