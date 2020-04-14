using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetGame : MonoBehaviour
{
    // We need a SCRAPER -- something that will COLLECT the value of placed pieces -- check with the WIN CONDITIONS -- and allow us to reset values
    // Reset PlayerPiece to "" -- this may involve setting up enum to start with ""
    // enable all buttons to be interactable 

    public PieceOperator placedPieces;
    public Button[] buttons;
    public Text[] buttonText;
    public Text newText;


    void Start()
    {
        Button[] buttons = GetComponentInChildren<Button[]>();
        Text[] buttonText = GetComponents<Text>();
    }

    public void Reset()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
            newText = button.GetComponentInChildren<Text>();
            newText.text = "";

            Debug.Log(button);
            // newText = button.GetComponent<Text>();
            // newText.text = "";
        }

        // foreach (Text text in buttonText)
        // {
        //     text = "";
        // }
        // placedPieces.button.interactable = true;
    }

    
}
