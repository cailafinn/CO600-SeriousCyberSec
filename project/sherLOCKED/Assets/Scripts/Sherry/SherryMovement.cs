using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherryMovement : MonoBehaviour
{

    float walkSpeed = 3f;

	Direction facing;
	Vector2 input;
	bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float time;
	
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
                StartCoroutine(Move(transform));
            }
        }
    }

    public IEnumerator Move(Transform entity) {
        isMoving = true;
        startPos = entity.position;
        time = 0;

        print(startPos);

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

enum Direction {
	North, 
	East, 
	South, 
	West
}
