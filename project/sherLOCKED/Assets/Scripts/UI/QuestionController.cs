using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public void Resume() {
        if (Time.timeScale == 0){
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
        }
	}
}
