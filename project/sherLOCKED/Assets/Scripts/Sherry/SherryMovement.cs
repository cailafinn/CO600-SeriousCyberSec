using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SherryMovement : MonoBehaviour
{

    // Publically Acessible variables
    public float walkSpeed = 3f;

    // Sprites for movement directions
    public Sprite northSpr;
    public Sprite eastSpr;
    public Sprite southSpr;
    public Sprite westSpr;

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
                // Change directional sprite
                if(input.x < 0) {
                    facing = Direction.West;
                } else if (input.x > 0) {
                    facing = Direction.East;
                } else if (input.y < 0) {
                    facing = Direction.South;
                } else if (input.y > 0) {
                    facing = Direction.North;
                }

                switch(facing){
                    case Direction.North:
                    gameObject.GetComponent<SpriteRenderer>().sprite = northSpr;
                    break;
                    case Direction.East:
                    gameObject.GetComponent<SpriteRenderer>().sprite = eastSpr;
                    break;
                    case Direction.South:
                    gameObject.GetComponent<SpriteRenderer>().sprite = southSpr;
                    break;
                    case Direction.West:
                    gameObject.GetComponent<SpriteRenderer>().sprite = westSpr;
                    break;
                }
                // Move character
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
