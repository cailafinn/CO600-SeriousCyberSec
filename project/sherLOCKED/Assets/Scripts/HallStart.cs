using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.Animations;

public class HallStart : MonoBehaviour
{
    // Reference to the Sherry prefab
    public GameObject sherryPrefab;
    // public float walkSpeed;
    // public GameObject interact;

    void Start()
    {
        //Instantiate Sherry at position (0.5,-2,0) and zero rotation
        //sherry = Instantiate(sherryPrefab, new Vector3(0.5f, -2, 0), Quaternion.identity); -> the right position for after testing
        sherryPrefab = Instantiate(sherryPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        
        sherryPrefab.transform.tag = "Player";
        sherryPrefab.GetComponent<Renderer>().sortingLayerName = "character";
        sherryPrefab.GetComponent<Renderer>().sortingOrder = 2;
        
        // Adding a Rigidbody2D with a frozen rotation
        Rigidbody2D rb = sherryPrefab.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        // Adding a BoxCollider2D used as a trigger
        BoxCollider2D bc = sherryPrefab.AddComponent<BoxCollider2D>();
        bc.offset = new Vector2(0, -0.5f);
        bc.size = new Vector2(1, 0.25f);
        bc.isTrigger = true;
        // Adding scripts to the player
        sherryPrefab.AddComponent<SherryMovement>();
        var sherryMove = sherryPrefab.GetComponent<SherryMovement>().walkSpeed;
        sherryMove = 5;
        //sherryMove.walkSpeed = 5;
        sherryPrefab.AddComponent<SherryInteract>();
        var sherryInteract = sherryPrefab.GetComponent<SherryInteract>().interact;
        sherryInteract = GameObject.Find("interactionSymbol");
        //sherryInteract.interact = interactionSymbol;
        // Adding a BoxCollider2D used by composite
        BoxCollider2D bc2 = sherryPrefab.AddComponent<BoxCollider2D>();
        bc2.offset = new Vector2(0, -0.5f);
        bc2.size = new Vector2(1, 0.25f);
        //bc2.usedByComposite = true;
        // Adding an animator to the player
        //sherry.AddComponent<Animator>();
        Animator anim = sherryPrefab.AddComponent<Animator>();
        var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/sherry_ac.controller");

    }

    // adds components to the instantiated prefab
    void FixedUpdate()
    {
        // // Adding a Rigidbody2D with a frozen rotation
        // Rigidbody2D rb = sherry.AddComponent<Rigidbody2D>();
        // rb.freezeRotation = true;
        // rb.gravityScale = 0;
        // rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        // // Adding a BoxCollider2D used as a trigger
        // BoxCollider2D bc = sherry.AddComponent<BoxCollider2D>();
        // bc.offset = new Vector2(0, -0.5f);
        // bc.size = new Vector2(1, 0.25f);
        // bc.isTrigger = true;
        // // Adding scripts to the player
        // sherry.AddComponent<SherryMovement>();
        // var sherryMove = sherry.GetComponent<SherryMovement>().walkSpeed;
        // sherryMove = 5;
        // //sherryMove.walkSpeed = 5;
        // sherry.AddComponent<SherryInteract>();
        // var sherryInteract = sherry.GetComponent<SherryInteract>().interact;
        // sherryInteract = GameObject.Find("interactionSymbol");
        // //sherryInteract.interact = interactionSymbol;
        // // Adding a BoxCollider2D used by composite
        // BoxCollider2D bc2 = sherry.AddComponent<BoxCollider2D>();
        // bc2.offset = new Vector2(0, -0.5f);
        // bc2.size = new Vector2(1, 0.25f);
        // //bc2.usedByComposite = true;
        // // Adding an animator to the player
        // //sherry.AddComponent<Animator>();
        // Animator anim = sherry.AddComponent<Animator>();
        // var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath("Assets/Animations/sherry_ac.controller");

    }
}
