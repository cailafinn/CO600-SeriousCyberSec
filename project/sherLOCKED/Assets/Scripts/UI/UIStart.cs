using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(GameObject.Find("Canvas"));
        UnityEngine.SceneManagement.SceneManager.LoadScene("Hall");
    }
}
