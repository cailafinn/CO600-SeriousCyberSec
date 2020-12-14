using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherryMovement : MonoBehaviour
{
    // Publically Acessible variables
    public float walkSpeed = 3f;

    // Movement control variables
	Vector2 input;
	bool isMoving = false;
    Rigidbody2D rb;

    // Animation controller
    Animator anim;

    // Called at start
    void Start() {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
    // Update is called once per frame
    void Update()
    {
        if(!isMoving){
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(Mathf.Abs(input.x) > Mathf.Abs(input.y)) {
                input.y = 0;
            } else {
                input.x = 0;
            }
            
            if(input != Vector2.zero) {
                // Control Animator
                anim.SetBool("isWalking", true);
                anim.SetFloat("input_x", input.x);
                anim.SetFloat("input_y", input.y);

                // Move character
                Move();
            } else {
                anim.SetBool("isWalking", false);
            }
        }
    }

    /**
    * Move the character smoothly according to the input vector
    */
    public void Move() {
        isMoving = true;

        if (Input.GetAxisRaw("Vertical") > 0) 
            rb.MovePosition(rb.position + Vector2.up * (Time.fixedDeltaTime * walkSpeed));
        else if (Input.GetAxisRaw("Vertical") < 0) 
            rb.MovePosition(rb.position + Vector2.down * (Time.fixedDeltaTime * walkSpeed));
        else if (Input.GetAxisRaw("Horizontal") < 0) 
            rb.MovePosition(rb.position + Vector2.left * (Time.fixedDeltaTime * walkSpeed));
        else if (Input.GetAxisRaw("Horizontal") > 0) 
            rb.MovePosition(rb.position + Vector2.right * (Time.fixedDeltaTime * walkSpeed));
        
        isMoving = false;
    }
}
