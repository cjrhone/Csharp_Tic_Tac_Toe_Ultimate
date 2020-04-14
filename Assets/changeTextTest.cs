using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeTextTest : MonoBehaviour
{
    public Text testText;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello. T4st");
        testText.text = "YO YO YO";

        Debug.Log(testText.text);
    }

    public void ClickityClack ()
    {
        testText.text = "I changed text";
    }

}
