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
    Vector3 startPos;
    Vector3 endPos;
    float time;

    // Animation controller
    Animator anim;

    // Called at start
    void Start() {
        anim = GetComponent<Animator>();
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
                StartCoroutine(Move(transform));
            } else {
                anim.SetBool("isWalking", false);
            }
        }
    }

    /**
    * Move the character smoothly according to the input vector
    * @ entity The entity to be moved
    */
    public IEnumerator Move(Transform entity) {
        isMoving = true;
        startPos = entity.position;
        time = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while(time < 1f) {
            time += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, time);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}
