using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Slider>();
    }

    public void SetValue(int value) {
        bar.value = value;
    }
}
