using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.UI;
using TMPro;
public class TextBoxController : MonoBehaviour
{
    public Image leftSprite;
    public Image rightSprite;
    public TextMeshProUGUI text;

    // Flag to say if text represents thoughts rather than speech
    private bool thought = false;

    // Is the left sprite in focus.
    private bool leftFocus;

    // Is the right sprite in focus.
    private bool rightFocus;

    // Start is called before the first frame update

    private Color light = new Color(1, 1, 1);
    private Color dark = new Color(0.25f, 0.25f, 0.25f);

    void Start()
    {
        leftFocus = false;
        rightFocus = false;
        Focus();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "AAAAAA";
    }

    void Focus() {
        if (leftFocus) {
            leftSprite.color = new Color(1, 1, 1);
        } else {
            leftSprite.color = new Color(0.25f, 0.25f, 0.25f);
        }
        if (rightFocus) {
            rightSprite.color = new Color(1, 1, 1);
        } else {
            rightSprite.color = new Color(0.25f, 0.25f, 0.25f);
        }
    }
}
