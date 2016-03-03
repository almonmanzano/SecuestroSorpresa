using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadingText : MonoBehaviour
{
    public float initial = 10.0f;
    public float substraction = 0.05f;

	void Start ()
    {
        Color color = GetComponent<Text>().color + new Color(0, 0, 0, initial);
        GetComponent<Text>().color = color;
    }
	
	void Update ()
    {
        Color color = GetComponent<Text>().color - new Color(0, 0, 0, substraction);
        GetComponent<Text>().color = color;
        if (color.a <= 0) Destroy(gameObject);
    }
}
