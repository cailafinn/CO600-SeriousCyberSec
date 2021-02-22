using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
    public void Resume() {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
	}
}
