using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;
using System.Collections.Generic;
using UnityEngine.UI;


public class HallStart : MonoBehaviour
{
    // Reference to the Sherry prefab
    public GameObject sherryPrefab;
    Canvas canvas;
    GameObject canvasObject;
    public GameObject interactionSymbol;
    Canvas QuestionCanvas;
    GameObject QCanvasObject;    
    Canvas ProgressCanvas;
    GameObject PCanvasObject;
    GameObject IntuitionBar;

    RectTransform rectTransform;

    void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0) {
            // Instantiate player when the game is loaded
            var sherry = Instantiate(sherryPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            sherry.GetComponent<SherryInteract>().interact = GameObject.Find("interactionSymbol");
            sherry.GetComponent<SherryProgress>().intuitionBar = GameObject.Find("IntuitionBar").GetComponent<ProgressBar>();  
            sherry.GetComponent<SherryProgress>().reputationBar = GameObject.Find("ReputationBar").GetComponent<ProgressBar>();
            sherry.transform.tag = "Player";
            sherry.GetComponent<Renderer>().sortingLayerName = "character";
            sherry.GetComponent<Renderer>().sortingOrder = 2;

            // Create a Canvas
            canvasObject = new GameObject();
            canvasObject.name = "Canvas";
            canvasObject.transform.tag = "Canvas";
            canvasObject.AddComponent<Canvas>();
            canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasObject.AddComponent<CanvasScaler>();
            canvasObject.AddComponent<GraphicRaycaster>();

            //Add interaction symbol
            interactionSymbol = Instantiate(interactionSymbol, new Vector3(20,20,0), Quaternion.identity) as GameObject;
            interactionSymbol.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Create question canvas
            QCanvasObject = new GameObject();
            QCanvasObject.name = "QuestionCanvas";
            QCanvasObject.AddComponent<Canvas>();
            QuestionCanvas = QCanvasObject.GetComponent<Canvas>();
            QuestionCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            QCanvasObject.AddComponent<CanvasScaler>();
            QCanvasObject.AddComponent<GraphicRaycaster>();
            QuestionCanvas.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Create progress canvas
            PCanvasObject = new GameObject();
            PCanvasObject.name = "ProgressCanvas";
            PCanvasObject.AddComponent<Canvas>();
            ProgressCanvas = PCanvasObject.GetComponent<Canvas>();
            ProgressCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            PCanvasObject.AddComponent<CanvasScaler>();
            PCanvasObject.AddComponent<GraphicRaycaster>();
            ProgressCanvas.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);

            // Add to question canvas
            GameObject imageObject = new GameObject();
            imageObject.transform.parent = canvasObject.transform;
            imageObject.name = "Image";
            Image image = imageObject.AddComponent<Image>();
            // image position
            rectTransform = image.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, -1.9073e-05f, 0);
            rectTransform.sizeDelta = new Vector2(703.6416f, 408.3467f);
            imageObject.GetComponent<MeshRenderer>().material.SetColor("_Color",Color.white);
            // Text
            GameObject textObject = new GameObject();
            textObject.transform.parent = canvasObject.transform;
            textObject.name = "Question";

            Text text = textObject.AddComponent<Text>();
            text.font = (Font)Resources.Load("Arial");
            text.text = "test";
            text.fontSize = 28;

            // Text position
            rectTransform = text.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(0, 100, 0);
            rectTransform.sizeDelta = new Vector2(500, 100);

            // Create intuition bar

        }
    }
}
